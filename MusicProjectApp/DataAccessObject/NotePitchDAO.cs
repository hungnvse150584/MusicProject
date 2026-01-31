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
    public class NotePitchDAO : BaseDAO<NotePitch>
    {
        private readonly MusicProjectContext _context;
        public NotePitchDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotePitch>> GetAllNotePitchesAsync()
        {
            return await _context.NotePitches
                                 .Include(np => np.MusicalEvent)
                                 .ToListAsync();
        }

        public async Task<NotePitch> GetNotePitchByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<NotePitch>()
                                       .Include(np => np.MusicalEvent)
                                       .SingleOrDefaultAsync(np => np.NotePitchID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
