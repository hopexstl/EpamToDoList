// <copyright file="TodoListController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Web.Controllers
{
    using Capstone.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.WebApi.Services;

    public class TodoListController : Controller
    {
        private readonly TodoListWebApiService todoListService;

        public TodoListController(TodoListWebApiService todoListService)
        {
            this.todoListService = todoListService;
        }

        [HttpGet("api/TodoList")]
        public async Task<IActionResult> GetTodoLists()
        {
            var todoLists = await this.todoListService.GetTodoListsAsync();
            return this.Ok(todoLists);
        }
    }
}
