using Microsoft.AspNetCore.Http;
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
    public class TupletGroupController : ControllerBase
    {
        private readonly ITupletGroupService _service;
        public TupletGroupController(ITupletGroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<TupletGroup>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<TupletGroup>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<TupletGroup>> Create([FromBody] TupletGroup req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<TupletGroup>> Update(int id, [FromBody] TupletGroup req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<TupletGroup>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
