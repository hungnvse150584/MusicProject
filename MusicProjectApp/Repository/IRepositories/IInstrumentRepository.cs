using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IInstrumentRepository : IBaseRepository<Instrument>
    {
        Task<IEnumerable<Instrument>> GetAllWithDetailsAsync();
        Task<Instrument> GetInstrumentByIdAsync(int id);
    }
}
