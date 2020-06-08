using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Carriers
{
    [Route("api/carriers")]
    public class CarriersController : BaseController
    {
        private readonly ICarriersService _service;

        public CarriersController(ICarriersService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCarriers()
        {
            return Get(_service.GetCarriers, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarrier(int id)
        {
            return Get(_service.GetCarrier, id);
        }

        [HttpPost]
        public IActionResult PostCarrier([FromBody]CarrierModel model)
        {
            return Post(_service.AddCarrier, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutCarrier(int id, [FromBody]CarrierModel model)
        {
            return Put(_service.UpdateCarrier, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarrier(int id)
        {
            return Delete(_service.DeleteCarrier, id);
        }
    }
}
