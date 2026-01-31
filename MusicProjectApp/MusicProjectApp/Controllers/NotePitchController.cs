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
    public class NotePitchesController : ControllerBase
    {
        private readonly INotePitchService _service;
        public NotePitchesController(INotePitchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<NotePitch>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<NotePitch>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<NotePitch>> Create([FromBody] NotePitch req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<NotePitch>> Update(int id, [FromBody] NotePitch req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<NotePitch>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
