using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SoundRepository : BaseRepository<Sound>, ISoundRepository
    {
        private readonly SoundDAO _dao;
        public SoundRepository(SoundDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Sound>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllSoundsAsync();
        }

        public async Task<Sound> GetSoundByIdAsync(int id)
        {
            return await _dao.GetSoundByIdAsync(id);
        }
    }
}
