using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;
using TodoListApi.Services;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;

        public TodoController(ILogger<TodoController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAll();
            _logger.LogInformation($"Retrieving all todo items. Count: {todos.Count}", todos.Count);
            return Ok(todos);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] TodoItem item)
        {
            _todoService.Add(item);
            _logger.LogInformation(
                $"Added new todo item with Id: {item.Id}, Task: {item.Task}, IsComplete: {item.IsComplete}",
                item.Id, item.Task, item.IsComplete);

            return CreatedAtAction(nameof(Add), item);
        }

        [HttpPost("update")]
        public IActionResult Update(TodoItem item)
        {
            if (item == null)
            {
                return BadRequest("Todo item cannot be null.");
            }

            var updated = _todoService.Update(item);
            if (!updated)
            {
                _logger.LogWarning(
                    $"Attempted to update todo item with Id: {item.Id}, but it was not found.", item.Id);
                return NotFound();
            }

            _logger.LogInformation(
                $"Updated todo item with Id: {item.Id}, Task: {item.Task}, IsComplete: {item.IsComplete}",
                item.Id, item.Task, item.IsComplete);

            return Ok(item);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(long id)
        {
            var removed = _todoService.Remove(id);
            if (!removed)
            {
                _logger.LogWarning($"Attempted to delete todo item with Id: {id}, but it was not found.", id);
                return NotFound();
            }

            _logger.LogInformation(
                $"Deleted todo item with Id: {id}", id);

            return Ok(id);
        }
    }
}
