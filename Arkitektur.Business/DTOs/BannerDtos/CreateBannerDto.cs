using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.BannerDtos
{
    public record CreateBannerDto(string Title, string Description, string ImageUrl);
}
