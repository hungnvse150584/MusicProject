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
    public class ClefRepository : BaseRepository<Clef>, IClefRepository
    {
        private readonly ClefDAO _clefDao;

        public ClefRepository(ClefDAO clefDao) : base(clefDao)
        {
           _clefDao = clefDao;
        }

        public async Task<IEnumerable<Clef>> GetAllWithDetailsAsync()
        {
            return await _clefDao.GetAllClefAsync();
        }

        public async Task<Clef> GetClefByIdAsync(int id)
        {
            return await _clefDao.GetClefByIdAsync(id);
        }

        public async Task<List<Clef>> AddListAsync(List<Clef> entity)
        {
            return await _clefDao.AddRange(entity);
        }

        public async Task<Clef> AddAsync(Clef entity)
        {
            return await _clefDao.AddAsync(entity);
        }

        public async Task<Clef> UpdateAsync(Clef entity)
        {
            return await _clefDao.UpdateAsync(entity);
        }

        public async Task<Clef> DeleteAsync(Clef entity)
        {
            return await _clefDao.DeleteAsync(entity);
        }
    }
}
