using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<IEnumerable<Note>> GetAllWithDetailsAsync();
        Task<Note> GetNoteByIdAsync(int id);
    }
}
