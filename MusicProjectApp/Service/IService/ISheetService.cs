using BusinessObject.Model;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Sheets;
using Service.RequestAndResponse.Request.Sheets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ISheetService
    {
        Task<BaseResponse<IEnumerable<SheetResponse>>> GetAllAsync();
        Task<BaseResponse<SheetResponse>> GetByIdAsync(int id);
        Task<BaseResponse<SheetResponse>> CreateAsync(CreateSheetRequest request);
        Task<BaseResponse<SheetResponse>> UpdateAsync(int id, UpdateSheetRequest request);
        Task<BaseResponse<SheetResponse>> DeleteAsync(int id);
    }
}
