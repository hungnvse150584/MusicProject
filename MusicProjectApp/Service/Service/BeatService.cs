using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Beats;
using Service.RequestAndResponse.Response.Beats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BeatService : IBeatService
    {
        private readonly IBeatRepository _repo;
        private readonly IMapper _mapper;

        public BeatService(IBeatRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<BeatResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<BeatResponse>(i));
            return new BaseResponse<IEnumerable<BeatResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<BeatResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetBeatByIdAsync(id);
                return new BaseResponse<BeatResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<BeatResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<BeatResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<BeatResponse>> CreateAsync(CreateBeatRequest request)
        {
            var entity = new Beat { MeasureID = request.MeasureID, BeatIndex = request.BeatIndex };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<BeatResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<BeatResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<BeatResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<BeatResponse>> UpdateAsync(int id, UpdateBeatRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.MeasureID = request.MeasureID;
                existing.BeatIndex = request.BeatIndex;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<BeatResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<BeatResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<BeatResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<BeatResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<BeatResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<BeatResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<BeatResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<BeatResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<BeatResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
