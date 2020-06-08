using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Users
{
    public interface IUsersRepository : IBaseRepository<ApplicationUser, UserModel>
    {
    }

    public class UsersRepository : BaseRepository<PSLContext, ApplicationUser, UserModel>, IUsersRepository
    {
        public UsersRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
