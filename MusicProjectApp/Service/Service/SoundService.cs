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
    public class SoundService : ISoundService
    {
        private readonly ISoundRepository _repo;
        private readonly IMapper _mapper;

        public SoundService(ISoundRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<Sound>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<Sound>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<Sound>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetSoundByIdAsync(id);
                return new BaseResponse<Sound>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Sound>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<Sound>> CreateAsync(Sound entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<Sound>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Sound>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<Sound>> UpdateAsync(int id, Sound entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.Name = entity.Name;
                existing.ProviderUrl = entity.ProviderUrl;
                existing.Format = entity.Format;
                existing.SampleRate = entity.SampleRate;
                existing.Channels = entity.Channels;
                existing.SizeBytes = entity.SizeBytes;
                existing.InstrumentType = entity.InstrumentType;
                existing.IsPremium = entity.IsPremium;
                existing.Price = entity.Price;
                existing.DefaultInstrumentID = entity.DefaultInstrumentID;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<Sound>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Sound>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Sound>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<Sound>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<Sound>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Sound>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Sound>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
