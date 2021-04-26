using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class WatermarkController : ApiController
    {
        public string Post([FromBody] Watermark req)
        {
            var response = Watermark.ProcessImage(req);
            return response;
        }
    }
}