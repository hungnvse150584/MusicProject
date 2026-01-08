using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.NoteTypes;
using Service.RequestAndResponse.Response.NoteTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NoteTypeService : INoteTypeService
    {
        private readonly INoteTypeRepository _repo;
        private readonly IMapper _mapper;

        public NoteTypeService(INoteTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<NoteTypeResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<NoteTypeResponse>(i));
            return new BaseResponse<IEnumerable<NoteTypeResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<NoteTypeResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetNoteTypeByIdAsync(id);
                return new BaseResponse<NoteTypeResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<NoteTypeResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteTypeResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<NoteTypeResponse>> CreateAsync(CreateNoteTypeRequest request)
        {
            var entity = new NoteType
            {
                NoteID = request.NoteID,
                NoteTypeName = request.NoteTypeName,
                Duration = request.Duration
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<NoteTypeResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<NoteTypeResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteTypeResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NoteTypeResponse>> UpdateAsync(int id, UpdateNoteTypeRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.NoteID = request.NoteID;
                existing.NoteTypeName = request.NoteTypeName;
                existing.Duration = request.Duration;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<NoteTypeResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<NoteTypeResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteTypeResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteTypeResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NoteTypeResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<NoteTypeResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<NoteTypeResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteTypeResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteTypeResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
