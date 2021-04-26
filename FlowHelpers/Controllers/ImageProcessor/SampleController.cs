using System.Net.Http;
using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class SampleController : ApiController
    {

        public HttpResponseMessage Post([FromBody] Sample req)
        {
            var response = Sample.ProcessImage(req);
            return response;
        }
    }
}