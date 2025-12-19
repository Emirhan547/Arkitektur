using Arkitektur.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.IGenericServices
{
    public interface IGenericService<TResult,TCreate,TUpdate>
    {
        Task<BaseResult<List<TResult>>> GetAllAsync();
        Task<BaseResult<TResult>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(TCreate create);
        Task<BaseResult<object>> UpdateAsync(TUpdate update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
