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
    public class RestRepository :  BaseRepository<Rest>, IRestRepository
    {
        private readonly RestDAO _restDao;

        public RestRepository(RestDAO restDao) : base(restDao)
        {
            _restDao = restDao;
        }

        public async Task<IEnumerable<Rest>> GetAllWithDetailsAsync()
        {
            return await _restDao.GetAllRestsAsync();
        }

        public async Task<Rest> GetRestByIdAsync(int id)
        {
            return await _restDao.GetRestByIdAsync(id);
        }

        public async Task<List<Rest>> AddListAsync(List<Rest> entity)
        {
            return await _restDao.AddRange(entity);
        }

        public async Task<Rest> AddAsync(Rest entity)
        {
            return await _restDao.AddAsync(entity);
        }

        public async Task<Rest> UpdateAsync(Rest entity)
        {
            return await _restDao.UpdateAsync(entity);
        }

        public async Task<Rest> DeleteAsync(Rest entity)
        {
            return await _restDao.DeleteAsync(entity);
        }
    }
}
