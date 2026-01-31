using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TupletGroupRepository : BaseRepository<TupletGroup>, ITupletGroupRepository
    {
        private readonly TupletGroupDAO _dao;
        public TupletGroupRepository(TupletGroupDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<TupletGroup>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllTupletGroupsAsync();
        }

        public async Task<TupletGroup> GetTupletGroupByIdAsync(int id)
        {
            return await _dao.GetTupletGroupByIdAsync(id);
        }
    }
}
