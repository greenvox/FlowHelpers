using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class AlphaController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] Alpha req)
        {
            var response = Alpha.ProcessImage(req);
            return response;
        }
    }
}