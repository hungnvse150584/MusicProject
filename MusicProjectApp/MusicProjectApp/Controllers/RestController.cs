using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Rests;
using Service.RequestAndResponse.Response.Rests;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestsController : ControllerBase
    {
        private readonly IRestService _service;
        public RestsController(IRestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<RestResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<RestResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<RestResponse>> Create(CreateRestRequest req) => await _service.CreateAsync(req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id:int}")]
        public async Task<BaseResponse<RestResponse>> Update(int id, UpdateRestRequest req) => await _service.UpdateAsync(id, req);

        [Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<RestResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
