using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerExample.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static IList<Todo> _todoItems = new List<Todo>();
        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoItems;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return _todoItems.First(item => item.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Todo value)
        {
            value.Id = _todoItems.Count + 1;
            _todoItems.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string description)
        {
            var item = _todoItems.First(i => i.Id == id);
            item.Description = description;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _todoItems.First(i => i.Id == id);
            _todoItems.Remove(item);
        }
    }
}
