using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.TimeSignatures;
using Service.RequestAndResponse.Request.TimeSignatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ITimeSignatureService
    {
        Task<BaseResponse<IEnumerable<TimeSignatureResponse>>> GetAllAsync();
        Task<BaseResponse<TimeSignatureResponse>> GetByIdAsync(int id);
        Task<BaseResponse<TimeSignatureResponse>> CreateAsync(CreateTimeSignatureRequest request);
        Task<BaseResponse<TimeSignatureResponse>> UpdateAsync(int id, UpdateTimeSignatureRequest request);
        Task<BaseResponse<TimeSignatureResponse>> DeleteAsync(int id);
    }
}
