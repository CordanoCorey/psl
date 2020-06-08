using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Routings
{
    [Route("api/routings")]
    public class RoutingsController : BaseController
    {
        private readonly IRoutingsService _service;

        public RoutingsController(IRoutingsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetRoutings()
        {
            return Get(_service.GetRoutings, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetRouting(int id)
        {
            return Get(_service.GetRouting, id);
        }

        [HttpPost]
        public IActionResult PostRouting([FromBody]RoutingModel model)
        {
            return Post(_service.AddRouting, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutRouting(int id, [FromBody]RoutingModel model)
        {
            return Put(_service.UpdateRouting, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRouting(int id)
        {
            return Delete(_service.DeleteRouting, id);
        }
    }
}
