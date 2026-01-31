using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IMusicalEventRepository : IBaseRepository<MusicalEvent>
    {
        Task<IEnumerable<MusicalEvent>> GetAllWithDetailsAsync();
        Task<MusicalEvent> GetMusicalEventByIdAsync(int id);
    }
}
