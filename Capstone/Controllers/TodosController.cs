using Capstone.Domain.Models;
using Capstone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Todo>> Get()
    {
        var todos = _todoService.Get();

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> GetById(int id)
    {
        var todo = _todoService.GetById(id);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);    
    }

    [HttpPost]
    public ActionResult Create(Todo todo)
    {
        _todoService.Create(todo);
        return NoContent();
    }

    [HttpPut]
    public ActionResult Update(Todo todo)
    {
        _todoService.Update(todo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _todoService.Delete(id);
        return NoContent();
    }

}
