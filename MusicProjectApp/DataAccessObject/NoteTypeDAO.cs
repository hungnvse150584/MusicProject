using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class NoteTypeDAO : BaseDAO<NoteType>
    {
        private readonly MusicProjectContext _context;
        public NoteTypeDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NoteType>> GetAllNoteTypeAsync()
        {
            return await _context.NoteTypes.ToListAsync();
        }

        public async Task<NoteType> GetNoteTypeByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<NoteType>()
                        .Include(c => c.Note)
               .SingleOrDefaultAsync(c => c.NoteTypeID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
