namespace TaskManagerAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskDbContext _context;

    public TasksController(TaskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetTasks()
    {
        return Ok(_context.Tasks.OrderBy(t => t.CreatedAt).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Task> GetTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<Task> CreateTask(CreateTaskRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return BadRequest("Title is required.");

        if (request.Title.Length > 100)
            return BadRequest("Title must not exceed 100 characters.");

        var task = new Task
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public ActionResult<Task> UpdateTask(int id, UpdateTaskRequest request)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return NotFound();

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            if (request.Title.Length > 100)
                return BadRequest("Title must not exceed 100 characters.");

            task.Title = request.Title;
        }

        if (request.Description != null)
            task.Description = request.Description;

        if (request.IsCompleted.HasValue)
            task.IsCompleted = request.IsCompleted.Value;

        _context.SaveChanges();

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return NoContent();
    }
}

public class CreateTaskRequest
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}

public class UpdateTaskRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? IsCompleted { get; set; }
}
