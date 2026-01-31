using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface ISoundPackItemService
    {
        Task<BaseResponse<IEnumerable<SoundPackItem>>> GetAllAsync();
        Task<BaseResponse<SoundPackItem>> GetByIdAsync(int id);
        Task<BaseResponse<SoundPackItem>> CreateAsync(SoundPackItem entity);
        Task<BaseResponse<SoundPackItem>> UpdateAsync(int id, SoundPackItem entity);
        Task<BaseResponse<SoundPackItem>> DeleteAsync(int id);
    }
}
