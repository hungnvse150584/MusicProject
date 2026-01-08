using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.TimeSignatures;
using Service.RequestAndResponse.Response.TimeSignatures;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/timesignatures")]
    [ApiController]
    public class TimeSignatureController : ControllerBase
    {
        private readonly ITimeSignatureService _service;
        public TimeSignatureController(ITimeSignatureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<TimeSignatureResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<TimeSignatureResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<TimeSignatureResponse>> Create(CreateTimeSignatureRequest req) => await _service.CreateAsync(req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id:int}")]
        public async Task<BaseResponse<TimeSignatureResponse>> Update(int id, UpdateTimeSignatureRequest req) => await _service.UpdateAsync(id, req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<TimeSignatureResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
