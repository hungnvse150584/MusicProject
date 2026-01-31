using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SoundPackItemRepository : BaseRepository<SoundPackItem>, ISoundPackItemRepository
    {
        private readonly SoundPackItemDAO _dao;
        public SoundPackItemRepository(SoundPackItemDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<SoundPackItem>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllItemsAsync();
        }

        public async Task<SoundPackItem> GetItemByIdAsync(int id)
        {
            return await _dao.GetItemByIdAsync(id);
        }
    }
}
