using Capstone.Domain.Models;

namespace Capstone.Services.Interfaces;

public interface ITodoService
{
    public IEnumerable<Todo> Get();
    public Todo GetById(int id);
    public void Create(Todo todo);
    public void Update(Todo todo);
    public void Delete(int id);
}
