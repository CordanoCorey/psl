using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psl.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Accounts
{
    [Route("api/accounts")]
    public class AccountsController : BaseController
    {
        private readonly IAccountsService _service;

        public AccountsController(IAccountsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Get(_service.GetAccounts, UserId);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            return Get(_service.GetAccount, id);
        }

        [HttpPost]
        public IActionResult PostAccount([FromBody]AccountModel model)
        {
            return Post(_service.AddAccount, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutAccount(int id, [FromBody]AccountModel model)
        {
            return Put(_service.UpdateAccount, model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return Delete(_service.DeleteAccount, id);
        }
    }
}
