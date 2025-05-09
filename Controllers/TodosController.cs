using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos(TodoStatus? status)
        {
            IQueryable<Todo> todos = _context.Todos;

            if (status.HasValue)
            {
                todos = todos.Where(t => t.Status == status.Value);
            }

            return await todos.ToListAsync();
        }

        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // POST: api/Todos
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            todo.CreatedDate = DateTime.UtcNow;
            todo.LastModifiedDate = DateTime.UtcNow;
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        // PUT: api/Todos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            var existingTodo = await _context.Todos.FindAsync(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.Status = todo.Status;
            existingTodo.Priority = todo.Priority;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.LastModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Todos/5/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Status = TodoStatus.Completed;
            todo.LastModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TodoExists(Guid id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}