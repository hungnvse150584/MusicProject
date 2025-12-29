using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class KeySignatureRepository : BaseRepository<KeySignature>, IKeySignatureRepository
    {
        private readonly KeySignatureDAO _keysignatureDao;

        public KeySignatureRepository(KeySignatureDAO keysignatureDao) : base(keysignatureDao)
        {
            _keysignatureDao = keysignatureDao;
        }

        public async Task<IEnumerable<KeySignature>> GetAllWithDetailsAsync()
        {
            return await _keysignatureDao.GetAllKeySignatureAsync();
        }

        public async Task<KeySignature> GetKeySignatureByIdAsync(int id)
        {
            return await _keysignatureDao.GetKeySignatureByIdAsync(id);
        }

        public async Task<List<KeySignature>> AddListAsync(List<KeySignature> entity)
        {
            return await _keysignatureDao.AddRange(entity);
        }

        public async Task<KeySignature> AddAsync(KeySignature entity)
        {
            return await _keysignatureDao.AddAsync(entity);
        }

        public async Task<KeySignature> UpdateAsync(KeySignature entity)
        {
            return await _keysignatureDao.UpdateAsync(entity);
        }

        public async Task<KeySignature> DeleteAsync(KeySignature entity)
        {
            return await _keysignatureDao.DeleteAsync(entity);
        }
    }
}
