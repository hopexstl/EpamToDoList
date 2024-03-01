// <copyright file="TodoController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Api.Controllers
{
    using Capstone.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using TodoListApp.Services.Models;

    /// <summary>
    /// Controller for managing todo items.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoListService todoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// </summary>
        /// <param name="todoService">The service for managing todo items.</param>
        public TodoController(ITodoListService todoService)
        {
            this.todoService = todoService;
        }

        /// <summary>
        /// Creates a new Todo List item.
        /// </summary>
        /// <param name="todo">The Todo List item to be created. This parameter is received from the request body.</param>
        /// <returns>
        /// A <see cref="IActionResult"/> that represents the result of the asynchronous operation.
        /// Returns a <see cref="NoContentResult"/> (HTTP 204) upon successful creation of the Todo List item,
        /// indicating that the request has been successfully processed but there is no content to return.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoList todo)
        {
            await this.todoService.AddTodoItem(todo);
            return this.NoContent();
        }
    }
}