using psl.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Infrastructure.Auth
{
    public interface IAuthRepository
    {
        bool HasAccessToAccount(long userId, long accountId, bool readonlyAccess);
    }
    public class AuthRepository : IAuthRepository
    {
        private readonly PSLContext _context;
        public AuthRepository(PSLContext context)
        {
            _context = context;
        }

        public bool HasAccessToAccount(long userId, long accountId, bool readonlyAccess)
        {
            //If it's a GET request then any role works.  
            //else a POST, PUT, or DEL then they need another role beyond simple member.
            //TODO-Find enums for role ids.
            return true;
        }
    }
}
