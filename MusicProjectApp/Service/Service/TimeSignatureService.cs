using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.TimeSignatures;
using Service.RequestAndResponse.Response.TimeSignatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TimeSignatureService : ITimeSignatureService
    {
        private readonly ITimeSignatureRepository _repo;
        private readonly IMapper _mapper;

        public TimeSignatureService(ITimeSignatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<TimeSignatureResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<TimeSignatureResponse>(i));
            return new BaseResponse<IEnumerable<TimeSignatureResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<TimeSignatureResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetTimeSignatureByIdAsync(id);
                return new BaseResponse<TimeSignatureResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<TimeSignatureResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TimeSignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<TimeSignatureResponse>> CreateAsync(CreateTimeSignatureRequest request)
        {
            var entity = new TimeSignature
            {
                BeatsPerMeasure = request.BeatsPerMeasure,
                BeatUnit = request.BeatUnit
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<TimeSignatureResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<TimeSignatureResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<TimeSignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<TimeSignatureResponse>> UpdateAsync(int id, UpdateTimeSignatureRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.BeatsPerMeasure = request.BeatsPerMeasure;
                existing.BeatUnit = request.BeatUnit;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<TimeSignatureResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<TimeSignatureResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TimeSignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TimeSignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<TimeSignatureResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<TimeSignatureResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<TimeSignatureResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TimeSignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TimeSignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
