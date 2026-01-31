using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface IMusicalEventService
    {
        Task<BaseResponse<IEnumerable<MusicalEvent>>> GetAllAsync();
        Task<BaseResponse<MusicalEvent>> GetByIdAsync(int id);
        Task<BaseResponse<MusicalEvent>> CreateAsync(MusicalEvent entity);
        Task<BaseResponse<MusicalEvent>> UpdateAsync(int id, MusicalEvent entity);
        Task<BaseResponse<MusicalEvent>> DeleteAsync(int id);
    }
}
