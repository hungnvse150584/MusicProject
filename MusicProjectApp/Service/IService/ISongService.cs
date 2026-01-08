using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Songs;
using Service.RequestAndResponse.Request.Songs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ISongService
    {
        Task<BaseResponse<IEnumerable<SongResponse>>> GetAllAsync();
        Task<BaseResponse<SongResponse>> GetByIdAsync(int id);
        Task<BaseResponse<SongResponse>> CreateAsync(CreateSongRequest request);
        Task<BaseResponse<SongResponse>> UpdateAsync(int id, UpdateSongRequest request);
        Task<BaseResponse<SongResponse>> DeleteAsync(int id);
    }
}
