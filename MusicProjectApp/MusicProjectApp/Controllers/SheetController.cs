using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.RequestAndResponse.Request.Sheets;
using Service.RequestAndResponse.Response.Sheets;
using Service.RequestAndResponse.BaseResponse;
using System.Threading.Tasks;
using Service.RequestAndResponse.Enums;
using BusinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace GreenRoam.Controllers
{
    [Route("api/sheets")]
    [ApiController]
    public class SheetController : ControllerBase
    {
        private readonly ISheetService _sheetService;
        public SheetController(ISheetService sheetService)
        {
            _sheetService = sheetService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<SheetResponse>>> GetAll()
        {
            return await _sheetService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<SheetResponse>> GetById(int id)
        {
            return await _sheetService.GetByIdAsync(id);
        }

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPost]
        public async Task<BaseResponse<SheetResponse>> Create(CreateSheetRequest request)
        {
            return await _sheetService.CreateAsync(request);
        }

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpPut("{id}")]
        public async Task<BaseResponse<SheetResponse>> Update(int id, UpdateSheetRequest request)
        {
            return await _sheetService.UpdateAsync(id, request);
        }

        //[Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseResponse<SheetResponse>> Delete(int id)
        {
            return await _sheetService.DeleteAsync(id);
        }

        [HttpPost("import/{songId}")]
        public async Task<BaseResponse<SheetResponse>> ImportMusicXml(IFormFile file, int songId, [FromQuery] string? author)
        {
            return await _sheetService.ImportMusicXmlAsync(file, songId, author);
        }

        [HttpPost("import-midi/{songId}")]
        public async Task<BaseResponse<SheetResponse>> ImportMidi(IFormFile file, int songId, [FromQuery] string? author)
        {
            return await _sheetService.ImportMidiAsync(file, songId, author);
        }
    }
}
