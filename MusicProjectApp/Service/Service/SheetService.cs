using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Sheets;
using Service.RequestAndResponse.Response.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SheetService : ISheetService
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IMapper _mapper;

        public SheetService(ISheetRepository sheetRepository, IMapper mapper)
        {
            _sheetRepository = sheetRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SheetResponse>>> GetAllAsync()
        {
            var sheets = await _sheetRepository.GetAllWithDetailsAsync();
            var data = sheets.Select(s => _mapper.Map<SheetResponse>(s));
            return new BaseResponse<IEnumerable<SheetResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<SheetResponse>> GetByIdAsync(int id)
        {
            try
            {
                var sheet = await _sheetRepository.GetSheetByIdAsync(id);
                var data = _mapper.Map<SheetResponse>(sheet);
                return new BaseResponse<SheetResponse>("Get Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> CreateAsync(CreateSheetRequest request)
        {
            var sheet = new Sheet
            {
                Author = request.Author,
                SongID = request.SongID,
                TimeSignatureID = request.TimeSignatureID,
                KeySignatureID = request.KeySignatureID
            };
            try
            {
                var created = await _sheetRepository.AddAsync(sheet);
                var data = _mapper.Map<SheetResponse>(created);
                return new BaseResponse<SheetResponse>("Create Success", StatusCodeEnum.Created_201, data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> UpdateAsync(int id, UpdateSheetRequest request)
        {
            try
            {
                var existing = await _sheetRepository.GetByIdAsync(id);
                existing.Author = request.Author;
                existing.SongID = request.SongID;
                existing.TimeSignatureID = request.TimeSignatureID;
                existing.KeySignatureID = request.KeySignatureID;
                var updated = await _sheetRepository.UpdateAsync(existing);
                var data = _mapper.Map<SheetResponse>(updated);
                return new BaseResponse<SheetResponse>("Update Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SheetResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _sheetRepository.GetByIdAsync(id);
                var deleted = await _sheetRepository.DeleteAsync(existing);
                var data = _mapper.Map<SheetResponse>(deleted);
                return new BaseResponse<SheetResponse>("Delete Success", StatusCodeEnum.OK_200, data);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SheetResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SheetResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
