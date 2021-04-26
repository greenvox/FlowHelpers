using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class FlipController : ApiController
    {
        public string Post([FromBody] Flip req)
        {
            var response = Flip.ProcessImage(req);
            return response;
        }
    }
}