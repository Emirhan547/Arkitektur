using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.BannerDtos
{
    public class CreateBannerDto
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public IFormFile? File { get; set; }
    }
}
