using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoListApi.Data;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TodoItemsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public List<TodoItem> Get()
        {
            return _db.TodoItems.OrderBy(x => x.IsDone).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            TodoItem todo = _db.TodoItems.Find(id);
            if (todo != null)
                return todo;

            return NotFound();
        }

        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _db.TodoItems.Add(todoItem);
                _db.SaveChanges();
                return todoItem;
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.TodoItems.Update(todoItem);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TodoItem todoItem = _db.TodoItems.Find(id);

            if (todoItem != null)
            {
                _db.TodoItems.Remove(todoItem);
                _db.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
