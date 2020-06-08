using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Users
{
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        /**
         *  GET: api/users
         */
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Get(_service.GetUsers, UserId);
        }

        /**
         *  GET: api/users/:id
         */
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Get(_service.GetUser, id);
        }

        /**
         *  POST: api/users
         */
        [HttpPost]
        public IActionResult PostUser([FromBody]UserModel model)
        {
            return Post(_service.AddUser, model);
        }

        /**
         *  PUT: api/users/{id}
         */
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody]UserModel model)
        {
            return Put(_service.UpdateUser, model);
        }

        /**
         *  DELETE: api/users/{id}
         */
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Delete(_service.DeleteUser, id);
        }
    }
}
