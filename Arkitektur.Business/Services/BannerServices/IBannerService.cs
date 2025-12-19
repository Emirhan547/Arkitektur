
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.Business.Services.IGenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.BannerServices
{
    public interface IBannerService:IGenericService<ResultBannerDto, CreateBannerDto, UpdateBannerDto>
    {
 
    }
}
