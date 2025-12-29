using BusinessObject.Model;
using Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INoteTypeRepository : IBaseRepository<NoteType>
    {
        Task<IEnumerable<NoteType>> GetAllWithDetailsAsync();
        Task<NoteType> GetNoteTypeByIdAsync(int id);
    }
}
