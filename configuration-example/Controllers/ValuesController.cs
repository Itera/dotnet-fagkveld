using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationExample.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly Appsettings appsettings;

        public ValuesController(IOptions<Appsettings> appsettings)
        {
            this.appsettings = appsettings.Value;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
