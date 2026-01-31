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
using static BusinessObject.Enums.MusicNotationEnums;

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
            var pitch = new NotePitch { Step = 0, Octave = request.Octave, Alter = (Alter)request.Alter };
            // Map incoming CreateNoteRequest into MusicalEvent; store single pitch in Pitches
            var entity = new MusicalEvent
            {
                MeasureID = request.MeasureID,
                StartBeat = request.StartBeat,
                DurationInBeats = request.Duration,
                IsChord = request.IsChord,
                Pitches = new List<NotePitch> { pitch }
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
                existing.StartBeat = request.StartBeat;
                existing.DurationInBeats = request.Duration;
                existing.IsChord = request.IsChord;

                // update first pitch if present
                var first = existing.Pitches.FirstOrDefault();
                if (first != null)
                {
                    first.Octave = request.Octave;
                    first.Alter = (Alter)request.Alter;
                    first.Step = 0; // leaving for compatibility (Step mapping not provided)
                }
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
