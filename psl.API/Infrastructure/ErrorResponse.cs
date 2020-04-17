using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace psl.API.Infrastructure
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }
}
