using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class InstrumentRepository : BaseRepository<Instrument>, IInstrumentRepository
    {
        private readonly InstrumentDAO _dao;
        public InstrumentRepository(InstrumentDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Instrument>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllInstrumentsAsync();
        }

        public async Task<Instrument> GetInstrumentByIdAsync(int id)
        {
            return await _dao.GetInstrumentByIdAsync(id);
        }
    }
}
