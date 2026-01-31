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
    public class NoteDAO : BaseDAO<MusicalEvent>
    {
        private readonly MusicProjectContext _context;
        public NoteDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MusicalEvent>> GetAllNoteAsync()
        {
            return await _context.MusicalEvents.ToListAsync();
        }

        public async Task<MusicalEvent> GetNoteByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<MusicalEvent>()
                        .Include(c => c.NoteTypes)
                        .Include(c => c.Measure)
               .SingleOrDefaultAsync(c => c.EventID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
