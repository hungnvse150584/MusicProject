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
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        private readonly TrackDAO _trackDao;

        public TrackRepository(TrackDAO trackDao) : base(trackDao)
        {
            _trackDao = trackDao;
        }

        public async Task<IEnumerable<Track>> GetAllWithDetailsAsync()
        {
            return await _trackDao.GetAllTracksAsync();
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            return await _trackDao.GetTrackByIdAsync(id);
        }

        public async Task<List<Track>> AddListAsync(List<Track> entity)
        {
            return await _trackDao.AddRange(entity);
        }

        public async Task<Track> AddAsync(Track entity)
        {
            return await _trackDao.AddAsync(entity);
        }

        public async Task<Track> UpdateAsync(Track entity)
        {
            return await _trackDao.UpdateAsync(entity);
        }

        public async Task<Track> DeleteAsync(Track entity)
        {
            return await _trackDao.DeleteAsync(entity);
        }
    }
}
