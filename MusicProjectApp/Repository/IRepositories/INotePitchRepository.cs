using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INotePitchRepository : IBaseRepository<NotePitch>
    {
        Task<IEnumerable<NotePitch>> GetAllWithDetailsAsync();
        Task<NotePitch> GetNotePitchByIdAsync(int id);
    }
}
