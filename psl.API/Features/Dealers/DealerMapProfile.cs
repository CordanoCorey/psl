using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Dealers
{
    public class DealerMapProfile : Profile
    {
        public DealerMapProfile()
        {
            CreateMap<Dealer, DealerModel>()
            .ReverseMap()
            ;
        }
    }
}
