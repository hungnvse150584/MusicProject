using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NotePitchService : INotePitchService
    {
        private readonly INotePitchRepository _repo;
        private readonly IMapper _mapper;

        public NotePitchService(INotePitchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<NotePitch>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<NotePitch>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<NotePitch>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetNotePitchByIdAsync(id);
                return new BaseResponse<NotePitch>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotePitch>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<NotePitch>> CreateAsync(NotePitch entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<NotePitch>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotePitch>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NotePitch>> UpdateAsync(int id, NotePitch entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.Step = entity.Step;
                existing.Octave = entity.Octave;
                existing.Alter = entity.Alter;
                existing.StringNumber = entity.StringNumber;
                existing.Fret = entity.Fret;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<NotePitch>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotePitch>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotePitch>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NotePitch>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<NotePitch>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotePitch>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotePitch>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
