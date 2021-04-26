using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class FormatController : ApiController
    {
        public string Post([FromBody] Format req)
        {
            var response = Format.ProcessImage(req);
            return response;
        }
    }
}