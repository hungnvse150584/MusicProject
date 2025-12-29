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
    public class BeatRepository : BaseRepository<Beat>, IBeatRepository
    {
        private readonly BeatDAO _beatDao;

        public BeatRepository(BeatDAO beatDao) : base(beatDao)
        {
            _beatDao = beatDao;
        }

        public async Task<IEnumerable<Beat>> GetAllWithDetailsAsync()
        {
            return await _beatDao.GetAllBeatAsync();
        }

        public async Task<Beat> GetBeatByIdAsync(int id)
        {
            return await _beatDao.GetBeatByIdAsync(id); 
        }

        public async Task<List<Beat>> AddListAsync(List<Beat> entity)
        {
            return await _beatDao.AddRange(entity);
        }

        public async Task<Beat> AddAsync(Beat entity)
        {
            return await _beatDao.AddAsync(entity);
        }

        public async Task<Beat> UpdateAsync(Beat entity)
        {
            return await _beatDao.UpdateAsync(entity);
        }

        public async Task<Beat> DeleteAsync(Beat entity)
        {
            return await _beatDao.DeleteAsync(entity);
        }

    }
}
