using AutoMapper;
using BusinessObject.Model;

using Service.RequestAndResponse.Request.Staffs;
using Service.RequestAndResponse.Response.Accounts;

using Service.RequestAndResponse.Response.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, GetAccountUser>().ReverseMap();
        }
      
    }

}