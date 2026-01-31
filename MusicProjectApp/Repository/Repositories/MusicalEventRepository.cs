using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MusicalEventRepository : BaseRepository<MusicalEvent>, IMusicalEventRepository
    {
        private readonly MusicalEventDAO _dao;
        public MusicalEventRepository(MusicalEventDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<MusicalEvent>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllMusicalEventsAsync();
        }

        public async Task<MusicalEvent> GetMusicalEventByIdAsync(int id)
        {
            return await _dao.GetMusicalEventByIdAsync(id);
        }
    }
}
