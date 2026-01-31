using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ISoundRepository : IBaseRepository<Sound>
    {
        Task<IEnumerable<Sound>> GetAllWithDetailsAsync();
        Task<Sound> GetSoundByIdAsync(int id);
    }
}
