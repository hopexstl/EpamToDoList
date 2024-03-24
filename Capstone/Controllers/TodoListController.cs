// <copyright file="TodoListController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApi.Controllers
{
    using System.Security.Claims;
    using Capstone.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.Models.TodoList;

    /// <summary>
    /// Controller for managing todo items.
    /// </summary>
    [Route("api/Todolist")]
    [ApiController]
    [Authorize]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService todoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListController"/> class.
        /// </summary>
        /// <param name="todoService">The service for managing todo items.</param>
        public TodoListController(ITodoListService todoService)
        {
            this.todoService = todoService;
        }

        /// <summary>
        /// Retrieves all todo lists from the service.
        /// </summary>
        /// <returns>A list of todo lists. The response is wrapped in an ActionResult for HTTP status code handling.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodoListsByUserId()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new NullReferenceException();
            }

            var todoListItems = await this.todoService.GetAllTodoListsByUserId(int.Parse(userId));
            return this.Ok(todoListItems);
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
        public async Task<IActionResult> CreateTodoItem(Todo todo)
        {
            await this.todoService.AddTodoItem(todo);
            return this.NoContent();
        }

        /// <summary>
        /// Deletes a TodoItem by its ID.
        /// </summary>
        /// <param name="itemId">The ID of the TodoItem to delete.</param>
        /// <returns>
        /// A NoContent result if the deletion is successful, or NotFound if a TodoItem with the specified ID does not exist.
        /// </returns>
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteTodoItem(int itemId)
        {
            try
            {
                await this.todoService.RemoveTodoItem(itemId);
                return this.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing TodoItem with the specified ID.
        /// </summary>
        /// <param name="itemId">The ID of the TodoItem to update.</param>
        /// <param name="updatedItem">The updated TodoItem information.</param>
        /// <returns>
        /// A NoContent result if the update is successful, BadRequest if the updatedItem is null,
        /// or NotFound if a TodoItem with the specified ID does not exist.
        /// </returns>
        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateTodoItem(int itemId, [FromBody] Todo updatedItem)
        {
            if (updatedItem == null)
            {
                return this.BadRequest("Invalid request body.");
            }

            try
            {
                await this.todoService.UpdateTodoItem(itemId, updatedItem);
                return this.Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}