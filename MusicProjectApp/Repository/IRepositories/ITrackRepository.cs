using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        Task<IEnumerable<Track>> GetAllWithDetailsAsync();
        Task<Track> GetTrackByIdAsync(int id);
    }
}
