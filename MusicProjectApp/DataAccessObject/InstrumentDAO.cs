using BusinessObject.Model;
using DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class InstrumentDAO : BaseDAO<Instrument>
    {
        private readonly MusicProjectContext _context;
        public InstrumentDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instrument>> GetAllInstrumentsAsync()
        {
            return await _context.Instruments
                .Include(i => i.DefaultSound)
                .ToListAsync();
        }

        public async Task<Instrument> GetInstrumentByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException($"id {id} not found");
            var entity = await _context.Set<Instrument>()
                .Include(i => i.DefaultSound)
                .SingleOrDefaultAsync(i => i.InstrumentID == id);
            if (entity == null) throw new ArgumentNullException($"Entity with id {id} not found");
            return entity;
        }
    }
}
