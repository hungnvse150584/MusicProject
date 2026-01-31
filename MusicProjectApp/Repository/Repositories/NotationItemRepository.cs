using BusinessObject.Model;
using DataAccessObject;
using Repository.BaseRepository;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class NotationItemRepository : BaseRepository<NotationItem>, INotationItemRepository
    {
        private readonly NotationItemDAO _dao;
        public NotationItemRepository(NotationItemDAO dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<NotationItem>> GetAllWithDetailsAsync()
        {
            return await _dao.GetAllNotationItemsAsync();
        }

        public async Task<NotationItem> GetNotationItemByIdAsync(int id)
        {
            return await _dao.GetNotationItemByIdAsync(id);
        }
    }
}
