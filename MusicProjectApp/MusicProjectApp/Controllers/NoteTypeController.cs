using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.NoteTypes;
using Service.RequestAndResponse.Response.NoteTypes;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteTypesController : ControllerBase
    {
        private readonly INoteTypeService _service;
        public NoteTypesController(INoteTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<NoteTypeResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<NoteTypeResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<NoteTypeResponse>> Create(CreateNoteTypeRequest req) => await _service.CreateAsync(req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id:int}")]
        public async Task<BaseResponse<NoteTypeResponse>> Update(int id, UpdateNoteTypeRequest req) => await _service.UpdateAsync(id, req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<NoteTypeResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
