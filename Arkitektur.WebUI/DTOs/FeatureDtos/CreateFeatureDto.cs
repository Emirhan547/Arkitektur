using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Icon { get; set; }
        [JsonIgnore]
        public IFormFile? File { get; set; }
    }
}
