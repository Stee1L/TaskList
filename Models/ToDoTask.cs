using System.ComponentModel.DataAnnotations;

namespace TaskList.Models;

public class ToDoTask
{
    [Key]
    public int TaskId { get; set; }
        
    [Required]
    public string Title { get; set; }
        
    public string Description { get; set; }
        
    public bool IsCompleted { get; set; }
}