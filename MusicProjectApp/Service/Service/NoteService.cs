using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Notes;
using Service.RequestAndResponse.Response.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repo;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<NoteResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<NoteResponse>(i));
            return new BaseResponse<IEnumerable<NoteResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<NoteResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetNoteByIdAsync(id);
                return new BaseResponse<NoteResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<NoteResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<NoteResponse>> CreateAsync(CreateNoteRequest request)
        {
            var entity = new Note
            {
                MeasureID = request.MeasureID,
                Pitch = request.Pitch,
                Octave = request.Octave,
                Alter = (BusinessObject.Model.Alter)request.Alter,
                Duration = request.Duration,
                StartBeat = request.StartBeat,
                IsChord = request.IsChord
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<NoteResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<NoteResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NoteResponse>> UpdateAsync(int id, UpdateNoteRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.MeasureID = request.MeasureID;
                existing.Pitch = request.Pitch;
                existing.Octave = request.Octave;
                existing.Alter = (BusinessObject.Model.Alter)request.Alter;
                existing.Duration = request.Duration;
                existing.StartBeat = request.StartBeat;
                existing.IsChord = request.IsChord;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<NoteResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<NoteResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NoteResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<NoteResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<NoteResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NoteResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
