using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SoundPackRepository : BaseRepository<SoundPack>, ISoundPackRepository
    {
        private readonly SoundPackDAO _dao;
        public SoundPackRepository(SoundPackDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<SoundPack>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllSoundPacksAsync();
        }

        public async Task<SoundPack> GetSoundPackByIdAsync(int id)
        {
            return await _dao.GetSoundPackByIdAsync(id);
        }
    }
}
