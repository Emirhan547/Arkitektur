using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.FeatureDtos
{
    public record UpdateFeatureDto(int Id, string? Title, string? Description, string? BackgroundImage, string? Icon);

}
