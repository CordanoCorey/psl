using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Carriers
{
    public interface ICarriersRepository : IBaseRepository<Carrier, CarrierModel>
    {
    }

    public class CarriersRepository : BaseRepository<PSLContext, Carrier, CarrierModel>, ICarriersRepository
    {
        public CarriersRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
