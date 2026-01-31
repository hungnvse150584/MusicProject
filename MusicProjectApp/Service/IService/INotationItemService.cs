using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Model;

namespace Service.IService
{
    public interface INotationItemService
    {
        Task<BaseResponse<IEnumerable<NotationItem>>> GetAllAsync();
        Task<BaseResponse<NotationItem>> GetByIdAsync(int id);
        Task<BaseResponse<NotationItem>> CreateAsync(NotationItem entity);
        Task<BaseResponse<NotationItem>> UpdateAsync(int id, NotationItem entity);
        Task<BaseResponse<NotationItem>> DeleteAsync(int id);
    }
}
    