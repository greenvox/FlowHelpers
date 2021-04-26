using System.Web.Http;
using FlowHelpers.Models;

namespace FlowHelpers.Controllers
{
    public class TintController : ApiController
    {
        public string Post([FromBody] Tint req)
        {
            var response = Tint.ProcessImage(req);
            return response;
        }
    }
}