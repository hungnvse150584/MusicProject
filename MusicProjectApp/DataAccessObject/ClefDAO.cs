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
    public class ClefDAO : BaseDAO<Clef>
    {
        private readonly MusicProjectContext _context;
        public ClefDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clef>> GetAllClefAsync()
        {
            return await _context.Clefs.ToListAsync();
        }

        public async Task<Clef> GetClefByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Clef>()
                        .Include(c => c.Tracks)
               .SingleOrDefaultAsync(c => c.ClefID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
