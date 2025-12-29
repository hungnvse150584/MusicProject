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
    public class NoteTypeRepository : BaseRepository<NoteType>, INoteTypeRepository
    {
        private readonly NoteTypeDAO _notetypeDao;

        public NoteTypeRepository(NoteTypeDAO notetypeDao) : base(notetypeDao)
        {
            _notetypeDao = notetypeDao;
        }

        public async Task<IEnumerable<NoteType>> GetAllWithDetailsAsync()
        {
            return await _notetypeDao.GetAllNoteTypeAsync();
        }

        public async Task<NoteType> GetNoteTypeByIdAsync(int id)
        {
            return await _notetypeDao.GetNoteTypeByIdAsync(id);
        }

        public async Task<List<NoteType>> AddListAsync(List<NoteType> entity)
        {
            return await _notetypeDao.AddRange(entity);
        }

        public async Task<NoteType> AddAsync(NoteType entity)
        {
            return await _notetypeDao.AddAsync(entity);
        }

        public async Task<NoteType> UpdateAsync(NoteType entity)
        {
            return await _notetypeDao.UpdateAsync(entity);
        }

        public async Task<NoteType> DeleteAsync(NoteType entity)
        {
            return await _notetypeDao.DeleteAsync(entity);
        }
    }
}
