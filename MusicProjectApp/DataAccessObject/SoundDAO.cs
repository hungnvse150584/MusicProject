using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class SoundDAO : BaseDAO<Sound>
    {
        private readonly MusicProjectContext _context;
        public SoundDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sound>> GetAllSoundsAsync()
        {
            return await _context.Sounds
                                 .Include(s => s.DefaultInstrument)
                                 .ToListAsync();
        }

        public async Task<Sound> GetSoundByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<Sound>()
                        .Include(s => s.DefaultInstrument)
                        .SingleOrDefaultAsync(s => s.SoundID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
