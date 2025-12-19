using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Arkitektur.WebUI.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Arkitektur.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenAiOptions _options;

        public AiController(IHttpClientFactory httpClientFactory, IOptions<OpenAiOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(_options.ApiKey))
            {
                return BadRequest(new { error = "OpenAI API anahtarı yapılandırılmadı." });
            }

            var messages = BuildMessages(request?.Messages);
            try
            {
                var payload = new
                {
                    model = string.IsNullOrWhiteSpace(_options.Model) ? "gpt-4o-mini" : _options.Model,
                    messages = messages.Select(m => new { role = m.Role, content = m.Content }),
                    temperature = 0.6
                };

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
                {
                    Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
                };
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);

                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(httpRequest);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var detail = ExtractErrorDetail(body) ?? response.ReasonPhrase ?? "Bilinmeyen hata";
                    return StatusCode((int)response.StatusCode, new { error = $"Asistan yanıtı alınamadı: {detail}" });
                }

                var reply = ExtractAssistantReply(body);
                return Ok(new { reply });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway,
                    new { error = $"OpenAI isteği başarısız oldu: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { error = $"Beklenmeyen bir hata oluştu: {ex.Message}" });
            }
        }

        private static IReadOnlyCollection<ChatMessage> BuildMessages(IEnumerable<ChatMessage>? messages)
        {
            var compiled = new List<ChatMessage>
            {
                new("system",
                    "You are a helpful assistant for the Arkitektur website. Keep responses concise and friendly.")
            };

            if (messages != null)
            {
                compiled.AddRange(messages
                    .Where(m => !string.IsNullOrWhiteSpace(m.Content))
                    .Select(m => new ChatMessage(m.Role?.ToLowerInvariant() ?? "user", m.Content!.Trim()))
                    .Take(25));
            }

            return compiled;
        }

        private static string ExtractAssistantReply(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                var choices = doc.RootElement.GetProperty("choices");
                if (choices.GetArrayLength() == 0) return "Yanıt alınamadı.";

                var message = choices[0].GetProperty("message");
                var content = message.GetProperty("content").GetString();
                return string.IsNullOrWhiteSpace(content) ? "Yanıt alınamadı." : content.Trim();
            }
            catch
            {
                return "Yanıt işlenirken bir sorun oluştu.";
            }
        }

        private static string? ExtractErrorDetail(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("error", out var errorProp))
                {
                    if (errorProp.ValueKind == JsonValueKind.String)
                    {
                        return errorProp.GetString();
                    }

                    if (errorProp.TryGetProperty("message", out var messageProp))
                    {
                        return messageProp.GetString();
                    }
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }
    }

    public record ChatRequest([property: JsonPropertyName("messages")] IEnumerable<ChatMessage>? Messages);

    public record ChatMessage(
        [property: JsonPropertyName("role")] string Role,
        [property: JsonPropertyName("content")] string Content);
}