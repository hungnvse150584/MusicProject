using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IKeySignatureRepository : IBaseRepository<KeySignature>
    {
        Task<IEnumerable<KeySignature>> GetAllWithDetailsAsync();
        Task<KeySignature> GetKeySignatureByIdAsync(int id);
    }
}
