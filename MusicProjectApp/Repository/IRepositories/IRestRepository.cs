using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IRestRepository : IBaseRepository<Rest>
    {
        Task<IEnumerable<Rest>> GetAllWithDetailsAsync();
        Task<Rest> GetRestByIdAsync(int id);
    }
}
