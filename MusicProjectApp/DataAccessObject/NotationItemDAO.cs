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
    public class NotationItemDAO : BaseDAO<NotationItem>
    {
        private readonly MusicProjectContext _context;
        public NotationItemDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotationItem>> GetAllNotationItemsAsync()
        {
            return await _context.NotationItems
                                 .Include(n => n.Measure)
                                 .ToListAsync();
        }

        public async Task<NotationItem> GetNotationItemByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<NotationItem>()
                                       .Include(n => n.Measure)
                                       .SingleOrDefaultAsync(n => n.NotationID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
