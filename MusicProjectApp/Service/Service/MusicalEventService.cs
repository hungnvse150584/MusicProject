using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MusicalEventService : IMusicalEventService
    {
        private readonly IMusicalEventRepository _repo;
        private readonly IMapper _mapper;

        public MusicalEventService(IMusicalEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<MusicalEvent>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<MusicalEvent>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<MusicalEvent>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetMusicalEventByIdAsync(id);
                return new BaseResponse<MusicalEvent>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MusicalEvent>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<MusicalEvent>> CreateAsync(MusicalEvent entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<MusicalEvent>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MusicalEvent>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<MusicalEvent>> UpdateAsync(int id, MusicalEvent entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                // Update allowed fields - keep associations/IDs stable
                existing.MeasureID = entity.MeasureID;
                existing.StartBeat = entity.StartBeat;
                existing.DurationInBeats = entity.DurationInBeats;
                existing.IsRest = entity.IsRest;
                existing.IsChord = entity.IsChord;
                existing.IsGraceNote = entity.IsGraceNote;
                existing.GraceDurationRatio = entity.GraceDurationRatio;
                existing.BaseNoteType = entity.BaseNoteType;
                existing.DotCount = entity.DotCount;
                existing.TupletID = entity.TupletID;

                // For Pitches and NoteTypes you may want special handling (replace/update). Here we replace collections if provided.
                if (entity.Pitches != null && entity.Pitches.Any())
                {
                    existing.Pitches = entity.Pitches;
                }

                if (entity.NoteTypes != null && entity.NoteTypes.Any())
                {
                    existing.NoteTypes = entity.NoteTypes;
                }

                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<MusicalEvent>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MusicalEvent>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MusicalEvent>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<MusicalEvent>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<MusicalEvent>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MusicalEvent>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MusicalEvent>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
