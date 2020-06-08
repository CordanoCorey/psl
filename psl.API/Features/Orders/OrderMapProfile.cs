using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Orders
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<Order, OrderModel>()
            .ReverseMap()
            ;
        }
    }
}
