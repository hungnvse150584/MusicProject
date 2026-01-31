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
    public class TupletGroupService : ITupletGroupService
    {
        private readonly ITupletGroupRepository _repo;
        private readonly IMapper _mapper;

        public TupletGroupService(ITupletGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<TupletGroup>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<TupletGroup>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<TupletGroup>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetTupletGroupByIdAsync(id);
                return new BaseResponse<TupletGroup>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TupletGroup>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<TupletGroup>> CreateAsync(TupletGroup entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<TupletGroup>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TupletGroup>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<TupletGroup>> UpdateAsync(int id, TupletGroup entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.ActualNotes = entity.ActualNotes;
                existing.NormalNotes = entity.NormalNotes;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<TupletGroup>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TupletGroup>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TupletGroup>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<TupletGroup>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<TupletGroup>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<TupletGroup>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TupletGroup>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
