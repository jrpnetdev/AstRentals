using System.Web.Http;

namespace AstRentals.Api.Controllers
{
    public class UserInfoController : ApiController
    {
        private static string Email { get; set; }

        [HttpGet]
        public string Get()
        {
            return Email;
        }

        [HttpPost]
        public int Post([FromBody]string email)
        {
            Email = email;

            return 1;
        }
    }
}