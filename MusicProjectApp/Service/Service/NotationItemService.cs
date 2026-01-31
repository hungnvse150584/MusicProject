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
    public class NotationItemService : INotationItemService
    {
        private readonly INotationItemRepository _repo;
        private readonly IMapper _mapper;

        public NotationItemService(INotationItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<NotationItem>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            return new BaseResponse<IEnumerable<NotationItem>>("Get All Success", StatusCodeEnum.OK_200, items);
        }

        public async Task<BaseResponse<NotationItem>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetNotationItemByIdAsync(id);
                return new BaseResponse<NotationItem>("Get Success", StatusCodeEnum.OK_200, item);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotationItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<NotationItem>> CreateAsync(NotationItem entity)
        {
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<NotationItem>("Create Success", StatusCodeEnum.Created_201, created);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotationItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NotationItem>> UpdateAsync(int id, NotationItem entity)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.StartBeat = entity.StartBeat;
                existing.EndBeat = entity.EndBeat;
                existing.Articulation = entity.Articulation;
                existing.Dynamic = entity.Dynamic;
                existing.Text = entity.Text;
                existing.IsLyric = entity.IsLyric;
                existing.IsStaffText = entity.IsStaffText;
                existing.IsCrescendo = entity.IsCrescendo;
                existing.IsDiminuendo = entity.IsDiminuendo;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<NotationItem>("Update Success", StatusCodeEnum.OK_200, updated);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotationItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotationItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<NotationItem>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<NotationItem>("Delete Success", StatusCodeEnum.OK_200, deleted);
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<NotationItem>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<NotationItem>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
