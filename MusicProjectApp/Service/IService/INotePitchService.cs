using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface INotePitchService
    {
        Task<BaseResponse<IEnumerable<NotePitch>>> GetAllAsync();
        Task<BaseResponse<NotePitch>> GetByIdAsync(int id);
        Task<BaseResponse<NotePitch>> CreateAsync(NotePitch entity);
        Task<BaseResponse<NotePitch>> UpdateAsync(int id, NotePitch entity);
        Task<BaseResponse<NotePitch>> DeleteAsync(int id);
    }
}
