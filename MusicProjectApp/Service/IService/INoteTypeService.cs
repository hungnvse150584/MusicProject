using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.NoteTypes;
using Service.RequestAndResponse.Request.NoteTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface INoteTypeService
    {
        Task<BaseResponse<IEnumerable<NoteTypeResponse>>> GetAllAsync();
        Task<BaseResponse<NoteTypeResponse>> GetByIdAsync(int id);
        Task<BaseResponse<NoteTypeResponse>> CreateAsync(CreateNoteTypeRequest request);
        Task<BaseResponse<NoteTypeResponse>> UpdateAsync(int id, UpdateNoteTypeRequest request);
        Task<BaseResponse<NoteTypeResponse>> DeleteAsync(int id);
    }
}
