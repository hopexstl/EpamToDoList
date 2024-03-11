using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebApp.Controllers
{
    public class TodoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
