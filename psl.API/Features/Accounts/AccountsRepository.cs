using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Accounts
{
    public interface IAccountsRepository : IBaseRepository<Account, AccountModel>
    {
    }

    public class AccountsRepository : BaseRepository<PSLContext, Account, AccountModel>, IAccountsRepository
    {
        public AccountsRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
