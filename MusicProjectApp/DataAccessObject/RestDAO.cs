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
    public class RestDAO : BaseDAO<Rest>
    {
        private readonly MusicProjectContext _context;
        public RestDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rest>> GetAllRestsAsync()
        {
            return await _context.Rests.ToListAsync();
        }

        public async Task<Rest> GetRestByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<Rest>()
                        .Include(c => c.Measure)
               .SingleOrDefaultAsync(c => c.RestID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
