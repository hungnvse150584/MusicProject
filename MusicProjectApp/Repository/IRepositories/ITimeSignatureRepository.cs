using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ITimeSignatureRepository : IBaseRepository<TimeSignature>
    {
        Task<IEnumerable<TimeSignature>> GetAllWithDetailsAsync();
        Task<TimeSignature> GetTimeSignatureByIdAsync(int id);
    }
}
