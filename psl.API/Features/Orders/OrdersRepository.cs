using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Orders
{
    public interface IOrdersRepository : IBaseRepository<Order, OrderModel>
    {
    }

    public class OrdersRepository : BaseRepository<PSLContext, Order, OrderModel>, IOrdersRepository
    {
        public OrdersRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
