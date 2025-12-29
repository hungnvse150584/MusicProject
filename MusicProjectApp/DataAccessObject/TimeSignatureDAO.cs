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
    public class TimeSignatureDAO : BaseDAO<TimeSignature>
    {
        private readonly MusicProjectContext _context;
        public TimeSignatureDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeSignature>> GetAllTimeSignaturesAsync()
        {
            return await _context.TimeSignatures.ToListAsync();
        }

        public async Task<TimeSignature> GetTimeSignatureByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<TimeSignature>()
                        .Include(c => c.Sheets)
               .SingleOrDefaultAsync(c => c.TimeSignatureID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
