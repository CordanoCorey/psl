using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Carriers
{
    public class CarrierMapProfile : Profile
    {
        public CarrierMapProfile()
        {
            CreateMap<Carrier, CarrierModel>()
            .ReverseMap()
            ;
        }
    }
}
