using AutoMapper;
using Microsoft.EntityFrameworkCore;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Routings
{
    public interface IRoutingsRepository : IBaseRepository<Routing, RoutingModel>
    {
    }

    public class RoutingsRepository : BaseRepository<PSLContext, Routing, RoutingModel>, IRoutingsRepository
    {
        public RoutingsRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Routing> IncludeAll(IQueryable<Routing> queryable)
        {
            return queryable
                .Include(x => x.Carrier)
                .Include(x => x.Destination)
                    .ThenInclude(y => y.State)
                .Include(x => x.Origin)
                    .ThenInclude(y => y.State)
            ;
        }

        protected override IQueryable<Routing> Include(IQueryable<Routing> queryable)
        {
            return queryable
                .Include(x => x.Carrier)
                .Include(x => x.Destination)
                    .ThenInclude(y => y.State)
                .Include(x => x.Origin)
                    .ThenInclude(y => y.State)
            ;
        }

        protected override IQueryable<Routing> IncludeSingle(IQueryable<Routing> queryable)
        {
            return queryable
                .Include(x => x.Carrier)
                .Include(x => x.Destination)
                    .ThenInclude(y => y.State)
                .Include(x => x.Origin)
                    .ThenInclude(y => y.State)
            ;
        }
    }
}
