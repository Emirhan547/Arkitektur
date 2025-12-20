using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.DTOs.FeatureDtos;

namespace Arkitektur.WebUI.Models
{
    public class FooterViewModel
    {
        public List<ResultContactDto> Contacts { get; set; } = new();
        public List<ResultFeatureDto> Features { get; set; } = new();
    }
}
