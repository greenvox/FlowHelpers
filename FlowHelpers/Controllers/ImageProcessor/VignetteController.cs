using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class VignetteController : ApiController
    {
        public string Post([FromBody] Vignette req)
        {
            var response = Vignette.ProcessImage(req);
            return response;
        }
    }
}