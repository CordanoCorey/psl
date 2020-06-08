using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Dealers
{
    [Route("api/dealers")]
    public class DealersController : BaseController
    {
        private readonly IDealersService _service;

        public DealersController(IDealersService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDealers()
        {
            return Get(_service.GetDealers, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetDealer(int id)
        {
            return Get(_service.GetDealer, id);
        }

        [HttpPost]
        public IActionResult PostDealer([FromBody]DealerModel model)
        {
            return Post(_service.AddDealer, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutDealer(int id, [FromBody]DealerModel model)
        {
            return Put(_service.UpdateDealer, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDealer(int id)
        {
            return Delete(_service.DeleteDealer, id);
        }
    }
}
