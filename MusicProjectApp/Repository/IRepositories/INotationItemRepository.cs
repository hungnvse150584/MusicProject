using BusinessObject.Model;
using Repository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INotationItemRepository : IBaseRepository<NotationItem>
    {
        Task<IEnumerable<NotationItem>> GetAllWithDetailsAsync();
        Task<NotationItem> GetNotationItemByIdAsync(int id);
    }
}
