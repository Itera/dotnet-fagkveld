using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace authentication_example.Controllers
{
    [Route("api/secrets")]
    [Authorize]
    public class SecretController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "This is a super-secret string you must be authenticated to see";
        }
    }
}