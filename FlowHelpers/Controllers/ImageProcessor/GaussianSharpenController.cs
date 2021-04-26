using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class GaussianSharpenController : ApiController
    {
        public string Post([FromBody] GaussianSharpen req)
        {
            var response = GaussianSharpen.ProcessImage(req);
            return response;
        }
    }
}