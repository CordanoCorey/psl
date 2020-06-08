using AutoMapper;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Widgets
{
    public class WidgetMapProfile : Profile
    {
        public WidgetMapProfile()
        {
            CreateMap<Widget, WidgetModel>()
            .ReverseMap()
            ;
        }
    }
}
