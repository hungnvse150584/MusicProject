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
    public class KeySignatureDAO : BaseDAO<KeySignature>
    {
        private readonly MusicProjectContext _context;
        public KeySignatureDAO(MusicProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KeySignature>> GetAllKeySignatureAsync()
        {
            return await _context.KeySignatures.ToListAsync();
        }

        public async Task<KeySignature> GetKeySignatureByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
            var entity = await _context.Set<KeySignature>()
                        .Include(c => c.Sheets)
               .SingleOrDefaultAsync(c => c.KeySignatureID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }
    }
}
