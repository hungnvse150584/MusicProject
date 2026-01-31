using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class MusicalEventDAO : BaseDAO<MusicalEvent>
    {
        private readonly MusicProjectContext _context;
        public MusicalEventDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MusicalEvent>> GetAllMusicalEventsAsync()
        {
            return await _context.MusicalEvents
                                 .Include(e => e.Measure)
                                 .Include(e => e.Pitches)
                                 .Include(e => e.NoteTypes)
                                 .Include(e => e.Tuplet)
                                 .ToListAsync();
        }

        public async Task<MusicalEvent> GetMusicalEventByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<MusicalEvent>()
                                       .Include(e => e.Measure)
                                       .Include(e => e.Pitches)
                                       .Include(e => e.NoteTypes)
                                       .Include(e => e.Tuplet)
                                       .SingleOrDefaultAsync(e => e.EventID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
