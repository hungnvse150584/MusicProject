using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TupletGroupDAO : BaseDAO<TupletGroup>
    {
        private readonly MusicProjectContext _context;
        public TupletGroupDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TupletGroup>> GetAllTupletGroupsAsync()
        {
            return await _context.TupletGroups.ToListAsync();
        }

        public async Task<TupletGroup> GetTupletGroupByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<TupletGroup>()
                                       .SingleOrDefaultAsync(t => t.TupletID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
