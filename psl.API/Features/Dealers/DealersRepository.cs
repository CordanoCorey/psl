using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Dealers
{
    public interface IDealersRepository : IBaseRepository<Dealer, DealerModel>
    {
    }

    public class DealersRepository : BaseRepository<PSLContext, Dealer, DealerModel>, IDealersRepository
    {
        public DealersRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
