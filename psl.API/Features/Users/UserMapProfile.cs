using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Users
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<ApplicationUser, UserModel>()
            .ReverseMap()
            ;
        }
    }
}
