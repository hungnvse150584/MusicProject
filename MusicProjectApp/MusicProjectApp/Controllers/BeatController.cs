using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Beats;
using Service.RequestAndResponse.Response.Beats;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeatsController : ControllerBase
    {
        private readonly IBeatService _service;
        public BeatsController(IBeatService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<BeatResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<BeatResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<BeatResponse>> Create(CreateBeatRequest req) => await _service.CreateAsync(req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id:int}")]
        public async Task<BaseResponse<BeatResponse>> Update(int id, UpdateBeatRequest req) => await _service.UpdateAsync(id, req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<BeatResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
