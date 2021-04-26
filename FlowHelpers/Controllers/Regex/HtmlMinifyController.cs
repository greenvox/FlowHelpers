using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class HtmlMinifyController : ApiController
    {
        public string Post([FromBody] HtmlMinify req)
        {
            var response = HtmlMinify.ProcessRequest(req);
            return response;
        }
    }
}