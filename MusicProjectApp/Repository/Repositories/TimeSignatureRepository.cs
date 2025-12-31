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
    public class TimeSignatureRepository : BaseRepository<TimeSignature>, ITimeSignatureRepository
    {
        private readonly TimeSignatureDAO _timesignatureDao;

        public TimeSignatureRepository(TimeSignatureDAO timesignatureDao) : base(timesignatureDao)
        {
            _timesignatureDao = timesignatureDao;
        }

        public async Task<IEnumerable<TimeSignature>> GetAllWithDetailsAsync()
        {
            return await _timesignatureDao.GetAllTimeSignaturesAsync();
        }

        public async Task<TimeSignature> GetTimeSignatureByIdAsync(int id)
        {
            return await _timesignatureDao.GetTimeSignatureByIdAsync(id);
        }

        public async Task<List<TimeSignature>> AddListAsync(List<TimeSignature> entity)
        {
            return await _timesignatureDao.AddRange(entity);
        }

        public async Task<TimeSignature> AddAsync(TimeSignature entity)
        {
            return await _timesignatureDao.AddAsync(entity);
        }

        public async Task<TimeSignature> UpdateAsync(TimeSignature entity)
        {
            return await _timesignatureDao.UpdateAsync(entity);
        }

        public async Task<TimeSignature> DeleteAsync(TimeSignature entity)
        {
            return await _timesignatureDao.DeleteAsync(entity);
        }
    }
}
