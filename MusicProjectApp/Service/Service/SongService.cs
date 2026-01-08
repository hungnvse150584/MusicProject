using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.Songs;
using Service.RequestAndResponse.Response.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repo;
        private readonly IMapper _mapper;

        public SongService(ISongRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SongResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<SongResponse>(i));
            return new BaseResponse<IEnumerable<SongResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<SongResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetSongByIdAsync(id);
                return new BaseResponse<SongResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<SongResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SongResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<SongResponse>> CreateAsync(CreateSongRequest request)
        {
            var entity = new Song
            {
                AccountID = request.AccountID,
                Name = request.Name,
                Composer = request.Composer,
                CreatedDate = DateTime.UtcNow
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<SongResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<SongResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<SongResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SongResponse>> UpdateAsync(int id, UpdateSongRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.AccountID = request.AccountID;
                existing.Name = request.Name;
                existing.Composer = request.Composer;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<SongResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<SongResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SongResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SongResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SongResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<SongResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<SongResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SongResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SongResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
