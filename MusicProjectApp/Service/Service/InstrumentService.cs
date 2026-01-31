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
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository _repo;
        private readonly IMapper _mapper;

        public InstrumentService(IInstrumentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<Instrument>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<Instrument>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<Instrument>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetInstrumentByIdAsync(id);
                return new BaseResponse<Instrument>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Instrument>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<Instrument>> CreateAsync(Instrument entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<Instrument>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Instrument>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<Instrument>> UpdateAsync(int id, Instrument entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.Name = entity.Name;
                existing.Type = entity.Type;
                existing.DefaultSoundID = entity.DefaultSoundID;
                existing.IsPublic = entity.IsPublic;
                existing.DisplayName = entity.DisplayName;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<Instrument>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Instrument>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Instrument>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<Instrument>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<Instrument>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<Instrument>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Instrument>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}