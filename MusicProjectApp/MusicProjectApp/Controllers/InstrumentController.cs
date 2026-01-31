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
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentService _service;
        public InstrumentsController(IInstrumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<Instrument>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<BaseResponse<Instrument>> GetById(int id) => await _service.GetByIdAsync(id);

        [HttpPost]
        public async Task<BaseResponse<Instrument>> Create([FromBody] Instrument req) => await _service.CreateAsync(req);

        [HttpPut("{id}")]
        public async Task<BaseResponse<Instrument>> Update(int id, [FromBody] Instrument req) => await _service.UpdateAsync(id, req);

        [HttpDelete("{id}")]
        public async Task<BaseResponse<Instrument>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
