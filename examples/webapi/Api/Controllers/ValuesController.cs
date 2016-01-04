using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("ping")]
        public IHttpActionResult NotSecured()
        {
            return this.Ok("All good. You don't need to be authenticated to call this.");
        }

        [Authorize]
        [HttpGet]
        [Route("secured/ping")]

        public IHttpActionResult Secured()
        {
            return this.Ok("All good. You only get this message if you are authenticated.");
        }
    }
}
