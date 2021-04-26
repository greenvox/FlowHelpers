using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class WeekRangeController : ApiController
    {

        // GET api/<controller>/5
        public WeekRangeResponse Post([FromBody] WeekRange req)
        {
            var response = WeekRange.ProcessRequest(req);
            return response;
        }


    }
}