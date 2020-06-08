using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Routings
{
    public class RoutingMapProfile : Profile
    {
        public RoutingMapProfile()
        {
            CreateMap<Routing, RoutingModel>()
                //.ForMember(d => d.CarrierName, o => o.MapFrom(s => s.Carrier.Name))
                //.ForMember(d => d.DestinationName, o => o.MapFrom(s => s.Destination.Name))
                //.ForMember(d => d.OriginName, o => o.MapFrom(s => s.Origin.Name))
            .ReverseMap()
            ;
        }
    }
}
