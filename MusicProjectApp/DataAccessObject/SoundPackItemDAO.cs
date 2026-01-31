using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class SoundPackItemDAO : BaseDAO<SoundPackItem>
    {
        private readonly MusicProjectContext _context;
        public SoundPackItemDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SoundPackItem>> GetAllItemsAsync()
        {
            return await _context.SoundPackItems
                .Include(i => i.Sound)
                .Include(i => i.SoundPack)
                .ToListAsync();
        }

        public async Task<SoundPackItem> GetItemByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<SoundPackItem>()
                .Include(i => i.Sound)
                .Include(i => i.SoundPack)
                .SingleOrDefaultAsync(i => i.SoundPackItemID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
