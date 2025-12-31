using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ISheetRepository : IBaseRepository<Sheet>
    {
        Task<IEnumerable<Sheet>> GetAllWithDetailsAsync();
        Task<Sheet> GetSheetByIdAsync(int id);
    }
}
