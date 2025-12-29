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
    public class BeatDAO : BaseDAO<Beat>
    {
        private readonly MusicProjectContext _context;
        public BeatDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beat>> GetAllBeatAsync()
        {
            return await _context.Beats.ToListAsync();
        }

        public async Task<Beat> GetBeatByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Beat>()
                        .Include(c => c.Measure)
               .SingleOrDefaultAsync(c => c.BeatID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
