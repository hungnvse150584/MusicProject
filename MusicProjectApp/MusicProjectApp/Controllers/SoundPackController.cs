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
    public class SoundPacksController : ControllerBase
    {
        private readonly ISoundPackService _service;
        public SoundPacksController(ISoundPackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<SoundPack>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<SoundPack>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<SoundPack>> Create([FromBody] SoundPack req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<SoundPack>> Update(int id, [FromBody] SoundPack req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<SoundPack>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
