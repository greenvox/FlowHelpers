using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class ResizeController : ApiController
    {

        // POST api/<controller>
        public string Post([FromBody] Resize req)
        {
            var response = Resize.ProcessImage(req);
            return response;
        }
    }
}