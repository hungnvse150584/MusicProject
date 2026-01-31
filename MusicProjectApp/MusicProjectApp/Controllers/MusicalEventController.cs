using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using BusinessObject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenRoam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicalEventController : ControllerBase
    {
        private readonly IMusicalEventService _service;
        public MusicalEventController(IMusicalEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<MusicalEvent>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<MusicalEvent>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<MusicalEvent>> Create([FromBody] MusicalEvent req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<MusicalEvent>> Update(int id, [FromBody] MusicalEvent req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<MusicalEvent>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
