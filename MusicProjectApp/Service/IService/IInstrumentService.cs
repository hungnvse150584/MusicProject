using Service.RequestAndResponse.BaseResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface IInstrumentService
    {
        Task<BaseResponse<IEnumerable<Instrument>>> GetAllAsync();
        Task<BaseResponse<Instrument>> GetByIdAsync(int id);
        Task<BaseResponse<Instrument>> CreateAsync(Instrument entity);
        Task<BaseResponse<Instrument>> UpdateAsync(int id, Instrument entity);
        Task<BaseResponse<Instrument>> DeleteAsync(int id);
    }
}
