using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.KeySignatures;
using Service.RequestAndResponse.Request.KeySignatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IKeySignatureService
    {
        Task<BaseResponse<IEnumerable<KeySignatureResponse>>> GetAllAsync();
        Task<BaseResponse<KeySignatureResponse>> GetByIdAsync(int id);
        Task<BaseResponse<KeySignatureResponse>> CreateAsync(CreateKeySignatureRequest request);
        Task<BaseResponse<KeySignatureResponse>> UpdateAsync(int id, UpdateKeySignatureRequest request);
        Task<BaseResponse<KeySignatureResponse>> DeleteAsync(int id);
    }
}
