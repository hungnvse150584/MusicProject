using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.KeySignatures;
using Service.RequestAndResponse.Response.KeySignatures;
using Service.RequestAndResponse.BaseResponse;
using Microsoft.AspNetCore.Authorization;

namespace GreenRoam.Controllers
{
    [Route("api/keysignatures")]
    [ApiController]
    public class KeySignatureController : ControllerBase
    {
        private readonly IKeySignatureService _service;
        public KeySignatureController(IKeySignatureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<KeySignatureResponse>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<KeySignatureResponse>> GetById(int id) => await _service.GetByIdAsync(id);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<KeySignatureResponse>> Create(CreateKeySignatureRequest req) => await _service.CreateAsync(req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id:int}")]
        public async Task<BaseResponse<KeySignatureResponse>> Update(int id, UpdateKeySignatureRequest req) => await _service.UpdateAsync(id, req);

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<KeySignatureResponse>> Delete(int id) => await _service.DeleteAsync(id);
    }
}
