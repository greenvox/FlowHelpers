using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class ConstrainController : ApiController
    {
        public string Post([FromBody] Constrain req)
        {
            var response = Constrain.ProcessImage(req);
            return response;
        }
    }
}