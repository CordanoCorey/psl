using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Widgets
{
    [Route("api/widgets")]
    public class WidgetsController : BaseController
    {
        private readonly IWidgetsService _service;

        public WidgetsController(IWidgetsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        /**
         *  GET: api/widgets
         */
        [HttpGet]
        public IActionResult GetWidgets()
        {
            return Get(_service.GetUserWidgets, UserId);
        }

        /**
         *  POST: api/widgets/user
         */
        [HttpPost("user")]
        public IActionResult AddUserWidgets([FromBody]IEnumerable<WidgetModel> model)
        {
            var result = _service.AddUserWidgets(UserId, model);
            return Ok(result);
        }

        /**
         *  POST: api/widgets
         */
        [HttpPost]
        public IActionResult PostWidget([FromBody]WidgetModel model)
        {
            return Post(_service.AddWidget, model);
        }

        /**
         *  PUT: api/widgets/{id}
         */
        [HttpPut("{id}")]
        public IActionResult PutWidget(int id, [FromBody]WidgetModel model)
        {
            return Put(_service.UpdateWidget, model);
        }

        /**
         *  DELETE: api/widgets/{id}
         */
        [HttpDelete("{id}")]
        public IActionResult DeleteWidget(int id)
        {
            return Delete(_service.DeleteWidget, id);
        }
    }
}
