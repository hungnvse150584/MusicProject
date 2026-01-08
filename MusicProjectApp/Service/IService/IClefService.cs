using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Clefs;
using Service.RequestAndResponse.Request.Clefs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IClefService
    {
        Task<BaseResponse<IEnumerable<ClefResponse>>> GetAllAsync();
        Task<BaseResponse<ClefResponse>> GetByIdAsync(int id);
        Task<BaseResponse<ClefResponse>> CreateAsync(CreateClefRequest request);
        Task<BaseResponse<ClefResponse>> UpdateAsync(int id, UpdateClefRequest request);
        Task<BaseResponse<ClefResponse>> DeleteAsync(int id);
    }
}
