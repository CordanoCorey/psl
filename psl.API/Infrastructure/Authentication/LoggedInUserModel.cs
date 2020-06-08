using psl.API.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Infrastructure.Authentication
{
    public class LoggedInUserModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        //public CurrentUserModel user { get; set; }
        public UserModel user { get; set; }
    }
}
