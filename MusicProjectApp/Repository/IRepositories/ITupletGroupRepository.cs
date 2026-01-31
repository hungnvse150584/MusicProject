using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ITupletGroupRepository : IBaseRepository<TupletGroup>
    {
        Task<IEnumerable<TupletGroup>> GetAllWithDetailsAsync();
        Task<TupletGroup> GetTupletGroupByIdAsync(int id);
    }
}
