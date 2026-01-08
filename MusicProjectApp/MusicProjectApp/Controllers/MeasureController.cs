using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Measures;
using Service.RequestAndResponse.Response.Measures;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasureService _service;
        public MeasuresController(IMeasureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<MeasureResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<MeasureResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<MeasureResponse>> Create(CreateMeasureRequest req) => await _service.CreateAsync(req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id}")]
        public async Task<BaseResponse<MeasureResponse>> Update(int id, UpdateMeasureRequest req) => await _service.UpdateAsync(id, req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseResponse<MeasureResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
