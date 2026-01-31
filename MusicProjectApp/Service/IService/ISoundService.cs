using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface ISoundService
    {
        Task<BaseResponse<IEnumerable<Sound>>> GetAllAsync();
        Task<BaseResponse<Sound>> GetByIdAsync(int id);
        Task<BaseResponse<Sound>> CreateAsync(Sound entity);
        Task<BaseResponse<Sound>> UpdateAsync(int id, Sound entity);
        Task<BaseResponse<Sound>> DeleteAsync(int id);
    }
}
