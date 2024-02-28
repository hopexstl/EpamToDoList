using Capstone.Domain.Models;

namespace Capstone.Services.Interfaces;

public interface ITodoService
{
    public IEnumerable<TodoList> Get();
    public TodoList GetById(int id);
    public void Create(TodoList todo);
    public void Update(TodoList todo);
    public void Delete(int id);
}
