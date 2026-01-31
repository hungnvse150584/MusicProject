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
    public class NoteRepository : BaseRepository<MusicalEvent>, INoteRepository
    {
        private readonly NoteDAO _noteDao;

        public NoteRepository(NoteDAO noteDao) : base(noteDao)
        {
            _noteDao = noteDao;
        }

        public async Task<IEnumerable<MusicalEvent>> GetAllWithDetailsAsync()
        {
           return await _noteDao.GetAllNoteAsync();
        }

        public async Task<MusicalEvent> GetNoteByIdAsync(int id)
        {
            return await _noteDao.GetNoteByIdAsync(id);
        }

        public async Task<List<MusicalEvent>> AddListAsync(List<MusicalEvent> entity)
        {
            return await _noteDao.AddRange(entity);
        }

        public async Task<MusicalEvent> AddAsync(MusicalEvent entity)
        {
            return await _noteDao.AddAsync(entity);
        }

        public async Task<MusicalEvent> UpdateAsync(MusicalEvent entity)
        {
            return await _noteDao.UpdateAsync(entity);
        }

        public async Task<MusicalEvent> DeleteAsync(MusicalEvent entity)
        {
            return await _noteDao.DeleteAsync(entity);
        }
    }
}
