using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ISoundPackItemRepository : IBaseRepository<SoundPackItem>
    {
        Task<IEnumerable<SoundPackItem>> GetAllWithDetailsAsync();
        Task<SoundPackItem> GetItemByIdAsync(int id);
    }
}
