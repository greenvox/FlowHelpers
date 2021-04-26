using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class PixelateController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody] Pixelate req)
        {
            var response = Pixelate.ProcessImage(req);
            return response;
        }
    }
}