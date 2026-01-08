using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Beats;
using Service.RequestAndResponse.Request.Beats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IBeatService
    {
        Task<BaseResponse<IEnumerable<BeatResponse>>> GetAllAsync();
        Task<BaseResponse<BeatResponse>> GetByIdAsync(int id);
        Task<BaseResponse<BeatResponse>> CreateAsync(CreateBeatRequest request);
        Task<BaseResponse<BeatResponse>> UpdateAsync(int id, UpdateBeatRequest request);
        Task<BaseResponse<BeatResponse>> DeleteAsync(int id);
    }
}
