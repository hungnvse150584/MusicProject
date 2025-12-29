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
    public class SheetDAO : BaseDAO<SheetDAO>
    {
        private readonly MusicProjectContext _context;
        public SheetDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sheet>> GetAllSheetsAsync()
        {
            return await _context.Sheets.ToListAsync();
        }

        public async Task<Sheet> GetSheetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Sheet>()
                        .Include(c => c.Song)
                        .Include(c => c.TimeSignature)
                        .Include(c => c.KeySignature)
               .SingleOrDefaultAsync(c => c.SheetID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
