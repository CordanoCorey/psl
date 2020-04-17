using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace psl.API.Infrastructure
{
    // Authors: Royce Brown, Corey Gelbaugh
    // Description: The base controller handles simple tasks like returning the correct response type and adding audit information.
    public class BaseController : Controller
    {
        private HttpContext _context { get; set; }
        private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext;

            //var headers = _context.Request.Headers;
            //var authHeader = headers["Authorization"];

            //if (authHeader.Any())
            //{

            //    var token = AuthenticationHeaderValue.Parse(headers["Authorization"]).Parameter;

            //    if (token != "")
            //    {
            //        var handler = new JwtSecurityTokenHandler();
            //        var result = handler.ReadJwtToken(token);
            //        _claims = result.Claims;
            //    }
            //}
        }
        protected int UserId
        {
            get
            {
                // return Int32.Parse(_claims.FirstOrDefault(x => x.Type == "UserId").Value);
                return 1;
            }
        }


        protected ActionResult Delete(Action<int> f, int id)
        {
            f(id);
            return NoContent();
        }

        protected ActionResult Delete(Action<int, int> f, int id1, int id2)
        {
            f(id1, id2);
            return NoContent();
        }

        protected ActionResult Delete(Action<string, int> f, string id1, int id2)
        {
            f(id1, id2);
            return NoContent();
        }

        protected ActionResult Get<T>(Func<T> f)
        {
            var result = f();
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<IEnumerable<T>> f)
        {
            var result = f();
            return Ok(result);
        }
        protected ActionResult Get<T>(Func<int, T> f, int id)
        {
            var result = f(id);
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<string, T> f, string id)
        {
            var result = f(id);
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<int, int, T> f, int id1, int id2)
        {
            var result = f(id1, id2);
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<int, QueryModel<T>, SearchResults<T>> f, int id, QueryModel<T> query = null)
        {
            var result = f(id, query);
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<IQueryModel<T>, IEnumerable<T>> f, IQueryModel<T> query = null)
        {
            var result = f(query);
            return Ok(result);
        }

        protected ActionResult Get<T>(Func<QueryModel<T>, SearchResults<T>> f, QueryModel<T> query = null)
        {
            var result = f(query);
            return Ok(result);
        }

        protected ActionResult Post<T>(Func<T, object> f, T value)
        {
            var result = f(value);
            return Ok(result);
        }

        protected ActionResult Post<T>(Func<T, T> f, T value, string routeName, Func<T, int> getId)
        {
            var result = f(value);
            return CreatedAtRoute(routeName, new { id = getId(result) }, result);
        }

        protected ActionResult Post<T>(Func<T, T> f, T value, string routeName, Func<T, object> getRouteValues)
        {
            var result = f(value);
            return CreatedAtRoute(routeName, getRouteValues(result), result);
        }

        protected ActionResult Post<T>(Func<IEnumerable<T>, IEnumerable<T>> f, IEnumerable<T> value, string routeName)
        {
            var results = f(value);
            return Ok(results);
        }

        protected ActionResult Post<T>(Func<int, T, T> f, int id, T value, string routeName)
        {
            var result = f(id, value);
            return Ok(result);
        }

        protected ActionResult Post<T>(Func<T, T> f, T value, string routeName) where T : IEntity
        {
            var result = f(value);
            return CreatedAtRoute(routeName, new { id = result.Id }, result);
        }

        protected ActionResult Post<T>(Func<int, IEnumerable<T>, IEnumerable<T>> f, int id, IEnumerable<T> value, string routeName) where T : IEntity
        {
            var results = f(id, value);
            return Ok(results);
        }

        protected ActionResult Put<T>(Func<T, T> f, T value)
        {
            var result = f(value);
            return Ok(result);
        }

        protected ActionResult Put<T>(Func<int, T, T> f, int id, T value)
        {
            var result = f(id, value);
            return Ok(result);
        }

        protected T AuditExisting<T>(T model) where T : BaseEntity
        {
            model.LastModifiedById = UserId;
            model.LastModifiedDate = DateTime.Now;
            return model;
        }

        protected T AuditNew<T>(T model) where T : BaseEntity
        {
            model.CreatedById = UserId;
            model.CreatedDate = DateTime.Now;
            model.LastModifiedById = UserId;
            model.LastModifiedDate = DateTime.Now;
            return model;
        }

        protected T Audit<T>(T model) where T : BaseEntity
        {
            return AuditExisting(AuditNew(model));
        }
    }
}
