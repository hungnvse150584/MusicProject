using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ISoundPackRepository : IBaseRepository<SoundPack>
    {
        Task<IEnumerable<SoundPack>> GetAllWithDetailsAsync();
        Task<SoundPack> GetSoundPackByIdAsync(int id);
    }
}
