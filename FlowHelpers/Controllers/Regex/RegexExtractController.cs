using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class RegexExtractController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] RegexExtract req)
        {
            var response = RegexExtract.ProcessRequest(req);
            return response;
        }
    }
}