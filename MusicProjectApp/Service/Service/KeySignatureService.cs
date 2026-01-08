using AutoMapper;
using BusinessObject.Model;
using Repository.IRepositories;
using Service.IService;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Enums;
using Service.RequestAndResponse.Request.KeySignatures;
using Service.RequestAndResponse.Response.KeySignatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class KeySignatureService : IKeySignatureService
    {
        private readonly IKeySignatureRepository _repo;
        private readonly IMapper _mapper;

        public KeySignatureService(IKeySignatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<KeySignatureResponse>>> GetAllAsync()
        {
            var items = await _repo.GetAllWithDetailsAsync();
            var data = items.Select(i => _mapper.Map<KeySignatureResponse>(i));
            return new BaseResponse<IEnumerable<KeySignatureResponse>>("Get All Success", StatusCodeEnum.OK_200, data);
        }

        public async Task<BaseResponse<KeySignatureResponse>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repo.GetKeySignatureByIdAsync(id);
                return new BaseResponse<KeySignatureResponse>("Get Success", StatusCodeEnum.OK_200, _mapper.Map<KeySignatureResponse>(item));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<KeySignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
        }

        public async Task<BaseResponse<KeySignatureResponse>> CreateAsync(CreateKeySignatureRequest request)
        {
            var entity = new KeySignature
            {
                KeyName = request.KeyName,
                Mode = request.Mode,
                AccidentalCount = request.AccidentalCount
            };
            try
            {
                var created = await _repo.AddAsync(entity);
                return new BaseResponse<KeySignatureResponse>("Create Success", StatusCodeEnum.Created_201, _mapper.Map<KeySignatureResponse>(created));
            }
            catch (Exception ex)
            {
                return new BaseResponse<KeySignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<KeySignatureResponse>> UpdateAsync(int id, UpdateKeySignatureRequest request)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                existing.KeyName = request.KeyName;
                existing.Mode = request.Mode;
                existing.AccidentalCount = request.AccidentalCount;
                var updated = await _repo.UpdateAsync(existing);
                return new BaseResponse<KeySignatureResponse>("Update Success", StatusCodeEnum.OK_200, _mapper.Map<KeySignatureResponse>(updated));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<KeySignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<KeySignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }

        public async Task<BaseResponse<KeySignatureResponse>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                var deleted = await _repo.DeleteAsync(existing);
                return new BaseResponse<KeySignatureResponse>("Delete Success", StatusCodeEnum.OK_200, _mapper.Map<KeySignatureResponse>(deleted));
            }
            catch (ArgumentNullException)
            {
                return new BaseResponse<KeySignatureResponse>("Not Found", StatusCodeEnum.NotFound_404, null);
            }
            catch (Exception ex)
            {
                return new BaseResponse<KeySignatureResponse>(ex.Message, StatusCodeEnum.InternalServerError_500, null);
            }
        }
    }
}
