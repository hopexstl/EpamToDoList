namespace TodoListApp.WebApi.Models.Models;

public class Task
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set;}

    public DateTime DueDate { get; set;}

    public TaskStatus TaskStatus { get; set;}

    public int CreatedById { get; set;}

    public int TaskAssignee { get; set;}
}
