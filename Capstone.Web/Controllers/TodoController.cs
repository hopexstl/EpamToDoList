// <copyright file="TodoController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.WebApi.Services;

    public class TodoController : Controller
    {
        private readonly TodoListWebApiService todoListService;

        public TodoController(TodoListWebApiService todoListService)
        {
            this.todoListService = todoListService;
        }
    }
}
