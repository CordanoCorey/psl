using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Products
{
    [Route("api/products")]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Get(_service.GetProducts, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Get(_service.GetProduct, id);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody]ProductModel model)
        {
            return Post(_service.AddProduct, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody]ProductModel model)
        {
            return Put(_service.UpdateProduct, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Delete(_service.DeleteProduct, id);
        }
    }
}
