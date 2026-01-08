using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Clefs;
using Service.RequestAndResponse.Response.Clefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ClefService : IClefService
    {
        private readonly IClefRepository _repo;
        private readonly IMapper _mapper;

        public ClefService(IClefRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ClefResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<ClefResponse>(i));
            return new BaseResponse<IEnumerable<ClefResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<ClefResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetClefByIdAsync(id);
                return new BaseResponse<ClefResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<ClefResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<ClefResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<ClefResponse>> CreateAsync(CreateClefRequest request)
        {
            var entity = new Clef { Name = request.Name };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<ClefResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<ClefResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClefResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<ClefResponse>> UpdateAsync(int id, UpdateClefRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.Name = request.Name;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<ClefResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<ClefResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<ClefResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClefResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<ClefResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<ClefResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<ClefResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<ClefResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClefResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
