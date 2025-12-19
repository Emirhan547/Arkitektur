using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.Services.GenericServices
{
    public interface IGenericService<TResult,TCreate,TUpdate>
    {
        Task<BaseResult<List<TResult>>> GetAllAsync();
        Task<BaseResult<TUpdate>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(TCreate create);
        Task<BaseResult<object>> UpdateAsync(TUpdate update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
