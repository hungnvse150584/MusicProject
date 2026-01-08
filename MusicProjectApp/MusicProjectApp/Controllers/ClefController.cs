using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Clefs;
using Service.RequestAndResponse.Response.Clefs;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClefsController : ControllerBase
    {
        private readonly IClefService _service;
        public ClefsController(IClefService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<ClefResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<ClefResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<ClefResponse>> Create(CreateClefRequest req) => await _service.CreateAsync(req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id}")]
        public async Task<BaseResponse<ClefResponse>> Update(int id, UpdateClefRequest req) => await _service.UpdateAsync(id, req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseResponse<ClefResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
