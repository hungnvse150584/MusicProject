using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Measures;
using Service.RequestAndResponse.Response.Measures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _repo;
        private readonly IMapper _mapper;

        public MeasureService(IMeasureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<MeasureResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<MeasureResponse>(i));
            return new BaseResponse<IEnumerable<MeasureResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<MeasureResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetMeasureByIdAsync(id);
                return new BaseResponse<MeasureResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<MeasureResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MeasureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<MeasureResponse>> CreateAsync(CreateMeasureRequest request)
        {
            var entity = new Measure { SongID = request.SongID, MeasureNumber = request.MeasureNumber };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<MeasureResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<MeasureResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<MeasureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<MeasureResponse>> UpdateAsync(int id, UpdateMeasureRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.SongID = request.SongID;
                existing.MeasureNumber = request.MeasureNumber;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<MeasureResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<MeasureResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MeasureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MeasureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<MeasureResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<MeasureResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<MeasureResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<MeasureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MeasureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
