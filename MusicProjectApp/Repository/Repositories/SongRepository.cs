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
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        private readonly SongDAO _songDao;

        public SongRepository(SongDAO songDao) : base(songDao)
        {
            _songDao = songDao;
        }

        public async Task<IEnumerable<Song>> GetAllWithDetailsAsync()
        {
            return await _songDao.GetAllSongsAsync();
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
           return await _songDao.GetSongByIdAsync(id);
        }

        public async Task<List<Song>> AddListAsync(List<Song> entity)
        {
            return await _songDao.AddRange(entity);
        }

        public async Task<Song> AddAsync(Song entity)
        {
            return await _songDao.AddAsync(entity);
        }

        public async Task<Song> UpdateAsync(Song entity)
        {
            return await _songDao.UpdateAsync(entity);
        }

        public async Task<Song> DeleteAsync(Song entity)
        {
            return await _songDao.DeleteAsync(entity);
        }
    }
}
