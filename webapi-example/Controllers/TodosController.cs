using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiExample.Controllers
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Text { get; set; }
    }




    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private static List<Todo> _todos = new List<Todo>();


        [HttpGet]
        [ResponseCache(Duration = 10)]
        public IEnumerable<Todo> Get() => _todos;


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _todos.SingleOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound($"Sorry, I couldn't find a todo by ID {id}");

            return Ok(entity);
        }


        [HttpPost]
        // [Authorize]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody]Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (todo.Id == 0)
            {
                todo.Id = _todos.Count + 1;
            }

            _todos.Add(todo);

            await Task.Delay(100);
            return Ok(todo);
        }


        [HttpPut("{id}")]
        // [Authorize]
        public void Put(int id, [FromBody]Todo todo)
        {
            _todos[_todos.FindIndex(e => e.Id == id)].Text = todo?.Text;
        }

    }
}
