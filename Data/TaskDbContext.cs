using Microsoft.EntityFrameworkCore;
using TaskList.Models;
namespace TaskList.Data;
public class TaskDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TaskDbContext(DbContextOptions<TaskDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<ToDoTask> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}