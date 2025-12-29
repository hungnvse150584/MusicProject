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
    public class MeasureDAO : BaseDAO<Measure>
    {
        private readonly MusicProjectContext _context;
        public MeasureDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measure>> GetAllMeasureAsync()
        {
            return await _context.Measures.ToListAsync();
        }

        public async Task<Measure> GetMeasureByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Measure>()
                        .Include(c => c.Beats)
                        .Include(c => c.Notes)
                        .Include(c => c.Rests)
               .SingleOrDefaultAsync(c => c.MeasureID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
