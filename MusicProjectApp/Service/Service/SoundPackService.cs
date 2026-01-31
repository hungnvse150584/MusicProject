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
    public class SoundPackService : ISoundPackService
    {
        private readonly ISoundPackRepository _repo;
        private readonly IMapper _mapper;

        public SoundPackService(ISoundPackRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SoundPack>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<SoundPack>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<SoundPack>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetSoundPackByIdAsync(id);
                return new BaseResponse<SoundPack>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPack>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<SoundPack>> CreateAsync(SoundPack entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<SoundPack>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPack>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SoundPack>> UpdateAsync(int id, SoundPack entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.Name = entity.Name;
                existing.Description = entity.Description;
                existing.IsPaid = entity.IsPaid;
                existing.Price = entity.Price;
                existing.IsPublished = entity.IsPublished;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<SoundPack>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPack>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPack>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<SoundPack>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<SoundPack>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<SoundPack>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<SoundPack>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}