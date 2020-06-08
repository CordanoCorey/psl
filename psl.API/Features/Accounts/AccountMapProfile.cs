using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Accounts
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<Account, AccountModel>()
            .ReverseMap()
            ;
        }
    }
}
