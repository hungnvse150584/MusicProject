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
    public class SoundsController : ControllerBase
    {
        private readonly ISoundService _service;
        public SoundsController(ISoundService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<Sound>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<Sound>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<Sound>> Create([FromBody] Sound req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<Sound>> Update(int id, [FromBody] Sound req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<Sound>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
