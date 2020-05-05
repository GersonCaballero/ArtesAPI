using System.Net;
using System.Web.Http;
using System.Threading;
using ArtesAPI.Models;
using System.Web.Http.Cors;
using System.Linq;

namespace ArtesAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login.Username == null || login.Password == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var user = db.Users.FirstOrDefault(x => x.UserName == login.Username && x.Password == login.Password && x.State == true);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            if (user != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
