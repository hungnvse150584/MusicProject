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
    public class NotationItemsController : ControllerBase
    {
        private readonly INotationItemService _service;
        public NotationItemsController(INotationItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<NotationItem>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<NotationItem>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<NotationItem>> Create([FromBody] NotationItem req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<NotationItem>> Update(int id, [FromBody] NotationItem req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<NotationItem>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
