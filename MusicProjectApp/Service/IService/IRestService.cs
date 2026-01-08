using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Rests;
using Service.RequestAndResponse.Request.Rests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IRestService
    {
        Task<BaseResponse<IEnumerable<RestResponse>>> GetAllAsync();
        Task<BaseResponse<RestResponse>> GetByIdAsync(int id);
        Task<BaseResponse<RestResponse>> CreateAsync(CreateRestRequest request);
        Task<BaseResponse<RestResponse>> UpdateAsync(int id, UpdateRestRequest request);
        Task<BaseResponse<RestResponse>> DeleteAsync(int id);
    }
}
