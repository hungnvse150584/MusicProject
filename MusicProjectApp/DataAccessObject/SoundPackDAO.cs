using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class SoundPackDAO : BaseDAO<SoundPack>
    {
        private readonly MusicProjectContext _context;
        public SoundPackDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SoundPack>> GetAllSoundPacksAsync()
        {
            return await _context.SoundPacks
                .Include(sp => sp.Items)
                    .ThenInclude(i => i.Sound)
                .ToListAsync();
        }

        public async Task<SoundPack> GetSoundPackByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<SoundPack>()
                .Include(sp => sp.Items)
                    .ThenInclude(i => i.Sound)
                .SingleOrDefaultAsync(sp => sp.SoundPackID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
