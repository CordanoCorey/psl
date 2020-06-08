using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Orders
{
    public interface IOrdersService
    {
        IEnumerable<OrderModel> GetOrders(int userId);
        OrderModel GetOrder(int id);
        OrderModel AddOrder(OrderModel model);
        OrderModel UpdateOrder(OrderModel model);
        void DeleteOrder(int id);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _repo;

        public OrdersService(IOrdersRepository repo)
        {
            _repo = repo;
        }

        public OrderModel AddOrder(OrderModel model)
        {
            var inserted = _repo.Insert(model);
            return GetOrder(inserted.Id);
        }

        public void DeleteOrder(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<OrderModel> GetOrders(int userId)
        {
            return _repo.All();
        }

        public OrderModel GetOrder(int id)
        {
            return _repo.FindByKey(id);
        }

        public OrderModel UpdateOrder(OrderModel model)
        {
            var updated = _repo.Update(model);
            return GetOrder(updated.Id);
        }
    }
}
