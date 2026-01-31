using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class NotePitchRepository : BaseRepository<NotePitch>, INotePitchRepository
    {
        private readonly NotePitchDAO _dao;
        public NotePitchRepository(NotePitchDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<NotePitch>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllNotePitchesAsync();
        }

        public async Task<NotePitch> GetNotePitchByIdAsync(int id)
        {
            return await _dao.GetNotePitchByIdAsync(id);
        }
    }
}
