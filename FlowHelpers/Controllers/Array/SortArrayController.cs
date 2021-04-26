using FlowHelpers.Models.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlowHelpers.Controllers.Array
{
    public class SortArrayController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] SortArray req)
        {
            var response = SortArray.ProcessRequest(req);
            return response;
        }
    }
}