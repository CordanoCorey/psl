using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Orders
{
    [Route("api/orders")]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Get(_service.GetOrders, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            return Get(_service.GetOrder, id);
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody]OrderModel model)
        {
            return Post(_service.AddOrder, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, [FromBody]OrderModel model)
        {
            return Put(_service.UpdateOrder, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Delete(_service.DeleteOrder, id);
        }
    }
}
