using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IMeasureRepository : IBaseRepository<Measure>
    {
        Task<IEnumerable<Measure>> GetAllWithDetailsAsync();
        Task<Measure> GetMeasureByIdAsync(int id);
    }
}
