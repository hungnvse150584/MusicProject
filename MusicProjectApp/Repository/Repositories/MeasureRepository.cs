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
    public class MeasureRepository : BaseRepository<Measure>, IMeasureRepository
    {
        private readonly MeasureDAO _measureDao;

        public MeasureRepository(MeasureDAO measureDao) : base(measureDao)
        {
            _measureDao = measureDao;
        }

        public async Task<IEnumerable<Measure>> GetAllWithDetailsAsync()
        {
            return await _measureDao.GetAllMeasureAsync();
        }

        public async Task<Measure> GetMeasureByIdAsync(int id)
        {
            return await _measureDao.GetMeasureByIdAsync(id);
        }

        public async Task<List<Measure>> AddListAsync(List<Measure> entity)
        {
            return await _measureDao.AddRange(entity);
        }

        public async Task<Measure> AddAsync(Measure entity)
        {
            return await _measureDao.AddAsync(entity);
        }

        public async Task<Measure> UpdateAsync(Measure entity)
        {
            return await _measureDao.UpdateAsync(entity);
        }

        public async Task<Measure> DeleteAsync(Measure entity)
        {
            return await _measureDao.DeleteAsync(entity);
        }
    }
}
