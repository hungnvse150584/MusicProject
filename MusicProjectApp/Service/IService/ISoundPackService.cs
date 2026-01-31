using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface ISoundPackService
    {
        Task<BaseResponse<IEnumerable<SoundPack>>> GetAllAsync();
        Task<BaseResponse<SoundPack>> GetByIdAsync(int id);
        Task<BaseResponse<SoundPack>> CreateAsync(SoundPack entity);
        Task<BaseResponse<SoundPack>> UpdateAsync(int id, SoundPack entity);
        Task<BaseResponse<SoundPack>> DeleteAsync(int id);
    }
}
