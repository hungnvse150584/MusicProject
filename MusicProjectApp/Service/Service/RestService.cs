using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Rests;
using Service.RequestAndResponse.Response.Rests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RestService : IRestService
    {
        private readonly IRestRepository _repo;
        private readonly IMapper _mapper;

        public RestService(IRestRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<RestResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<RestResponse>(i));
            return new BaseResponse<IEnumerable<RestResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<RestResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetRestByIdAsync(id);
                return new BaseResponse<RestResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<RestResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<RestResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<RestResponse>> CreateAsync(CreateRestRequest request)
        {
            var entity = new Rest
            {
                MeasureID = request.MeasureID,
                Duration = request.Duration,
                StartBeat = request.StartBeat
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<RestResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<RestResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<RestResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<RestResponse>> UpdateAsync(int id, UpdateRestRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.MeasureID = request.MeasureID;
                existing.Duration = request.Duration;
                existing.StartBeat = request.StartBeat;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<RestResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<RestResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<RestResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<RestResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<RestResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<RestResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<RestResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<RestResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<RestResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
