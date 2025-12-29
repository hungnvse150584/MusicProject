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
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        private readonly NoteDAO _noteDao;

        public NoteRepository(NoteDAO noteDao) : base(noteDao)
        {
            _noteDao = noteDao;
        }

        public async Task<IEnumerable<Note>> GetAllWithDetailsAsync()
        {
           return await _noteDao.GetAllNoteAsync();
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _noteDao.GetNoteByIdAsync(id);
        }

        public async Task<List<Note>> AddListAsync(List<Note> entity)
        {
            return await _noteDao.AddRange(entity);
        }

        public async Task<Note> AddAsync(Note entity)
        {
            return await _noteDao.AddAsync(entity);
        }

        public async Task<Note> UpdateAsync(Note entity)
        {
            return await _noteDao.UpdateAsync(entity);
        }

        public async Task<Note> DeleteAsync(Note entity)
        {
            return await _noteDao.DeleteAsync(entity);
        }
    }
}
