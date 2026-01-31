using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public class SoundPackItemService : ISoundPackItemService
    {
        private readonly ISoundPackItemRepository _repo;
        private readonly IMapper _mapper;

        public SoundPackItemService(ISoundPackItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SoundPackItem>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<SoundPackItem>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<SoundPackItem>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetItemByIdAsync(id);
                return new BaseResponse<SoundPackItem>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPackItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<SoundPackItem>> CreateAsync(SoundPackItem entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<SoundPackItem>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPackItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SoundPackItem>> UpdateAsync(int id, SoundPackItem entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.SoundID = entity.SoundID;
                existing.SoundPackID = entity.SoundPackID;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<SoundPackItem>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPackItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPackItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SoundPackItem>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<SoundPackItem>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPackItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPackItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
