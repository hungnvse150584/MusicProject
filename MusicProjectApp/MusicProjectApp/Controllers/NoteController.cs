using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Notes;
using Service.RequestAndResponse.Response.Notes;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;
        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<NoteResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<NoteResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<NoteResponse>> Create(CreateNoteRequest req) => await _service.CreateAsync(req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id}")]
        public async Task<BaseResponse<NoteResponse>> Update(int id, UpdateNoteRequest req) => await _service.UpdateAsync(id, req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseResponse<NoteResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
