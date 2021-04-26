using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class GaussianBlurController : ApiController
    {
        public string Post([FromBody] GaussianBlur req)
        {
            var response = GaussianBlur.ProcessImage(req);
            return response;
        }
    }
}