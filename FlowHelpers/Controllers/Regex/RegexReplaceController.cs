using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class RegexReplaceController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] RegexReplace req)
        {
            var response = RegexReplace.ProcessRequest(req);
            return response;
        }
    }
}