using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class SaturationController : ApiController
    {
        public string Post([FromBody] Saturation req)
        {
            var response = Saturation.ProcessImage(req);
            return response;
        }
    }
}