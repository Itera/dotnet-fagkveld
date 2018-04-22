using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DiExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IEnumerable<IRepository> repositories;

        public ValuesController(IEnumerable<IRepository> repositories)
        {
            this.repositories = repositories;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return repositories.Select(r=>r.GetText());
        }
    }
}
