using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Measures;
using Service.RequestAndResponse.Request.Measures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IMeasureService
    {
        Task<BaseResponse<IEnumerable<MeasureResponse>>> GetAllAsync();
        Task<BaseResponse<MeasureResponse>> GetByIdAsync(int id);
        Task<BaseResponse<MeasureResponse>> CreateAsync(CreateMeasureRequest request);
        Task<BaseResponse<MeasureResponse>> UpdateAsync(int id, UpdateMeasureRequest request);
        Task<BaseResponse<MeasureResponse>> DeleteAsync(int id);
    }
}
