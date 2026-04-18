namespace TaskManagerAPI.Data;

using TaskManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; } = null!;
}
