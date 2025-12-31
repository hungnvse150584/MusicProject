using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IBaseRepository;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SheetRepository : BaseRepository<Sheet>, ISheetRepository
    {
        private readonly SheetDAO _sheetDao;

        public SheetRepository(SheetDAO sheetDao) : base(sheetDao)
        {
            _sheetDao = sheetDao;
        }
        public async Task<IEnumerable<Sheet>> GetAllWithDetailsAsync()
        {
           return await _sheetDao.GetAllSheetsAsync();
        }

        public async Task<Sheet> GetSheetByIdAsync(int id)
        {
            return await _sheetDao.GetSheetByIdAsync(id);
        }

        public async Task<List<Sheet>> AddListAsync(List<Sheet> entity)
        {
            return await _sheetDao.AddRange(entity);
        }

        public async Task<Sheet> AddAsync(Sheet entity)
        {
            return await _sheetDao.AddAsync(entity);
        }

        public async Task<Sheet> UpdateAsync(Sheet entity)
        {
            return await _sheetDao.UpdateAsync(entity);
        }

        public async Task<Sheet> DeleteAsync(Sheet entity)
        {
            return await _sheetDao.DeleteAsync(entity);
        }
    }
}
