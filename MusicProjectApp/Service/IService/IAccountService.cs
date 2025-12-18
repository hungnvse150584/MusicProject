using BusinessObject.Model;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAccountService
    {
        Task<Account> GetByStringId(string id);
        Task<BaseResponse<GetTotalAccount>> GetTotalAccount();
    }
}
