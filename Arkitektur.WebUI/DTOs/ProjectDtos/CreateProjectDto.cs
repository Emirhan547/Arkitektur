using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.ProjectDtos
{
    public class CreateProjectDto
    {
    public string? ImageUrl { get; set; }
    [JsonIgnore]
    public IFormFile? File { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Item1 { get; set; }
    public string? Item2 { get; set; }
    public string? Item3 { get; set; }
    public int CategoryId { get; set; }

}
}