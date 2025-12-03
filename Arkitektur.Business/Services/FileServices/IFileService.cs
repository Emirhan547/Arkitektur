using Arkitektur.Business.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.FileServices;

public interface IFileService
{
    Task<BaseResult<object>> UploadImageToS3Async(IFormFile? file);

    Task<BaseResult<object>> DeleteFileAsync(string imageUrl);

}