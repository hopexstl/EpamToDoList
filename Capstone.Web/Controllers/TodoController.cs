// <copyright file="TodoController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.WebApi.Services;

    /// <summary>
    /// The TodoController is responsible for handling HTTP requests related to Todo items.
    /// It interacts with the TodoListWebApiService to perform CRUD operations on Todo items.
    /// </summary>
    public class TodoController : Controller
    {
        private readonly TodoListWebApiService todoListService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// </summary>
        /// <param name="todoListService">The TodoListWebApiService instance used for interacting with Todo items.</param>
        public TodoController(TodoListWebApiService todoListService)
        {
            this.todoListService = todoListService;
        }
    }
}
