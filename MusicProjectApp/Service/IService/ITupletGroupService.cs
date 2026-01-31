using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface ITupletGroupService
    {
        Task<BaseResponse<IEnumerable<TupletGroup>>> GetAllAsync();
        Task<BaseResponse<TupletGroup>> GetByIdAsync(int id);
        Task<BaseResponse<TupletGroup>> CreateAsync(TupletGroup entity);
        Task<BaseResponse<TupletGroup>> UpdateAsync(int id, TupletGroup entity);
        Task<BaseResponse<TupletGroup>> DeleteAsync(int id);
    }
}
