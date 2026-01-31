using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using BusinessObject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicProjectApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundPackItemsController : ControllerBase
    {
        private readonly ISoundPackItemService _service;
        public SoundPackItemsController(ISoundPackItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<SoundPackItem>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<SoundPackItem>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<SoundPackItem>> Create([FromBody] SoundPackItem req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<SoundPackItem>> Update(int id, [FromBody] SoundPackItem req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<SoundPackItem>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
