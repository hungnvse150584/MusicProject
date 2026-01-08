using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Notes;
using Service.RequestAndResponse.Request.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface INoteService
    {
        Task<BaseResponse<IEnumerable<NoteResponse>>> GetAllAsync();
        Task<BaseResponse<NoteResponse>> GetByIdAsync(int id);
        Task<BaseResponse<NoteResponse>> CreateAsync(CreateNoteRequest request);
        Task<BaseResponse<NoteResponse>> UpdateAsync(int id, UpdateNoteRequest request);
        Task<BaseResponse<NoteResponse>> DeleteAsync(int id);
    }
}
