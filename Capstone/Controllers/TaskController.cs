// <copyright file="TaskController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoList.Services.Interfaces;
using TodoList.Services.Models.Task;
using TodoListApp.WebApi.Models.Enum;

namespace TodoList.WebApi.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to tasks in the TodoList application.
    /// This controller provides endpoints for operations such as creating, retrieving, updating, and deleting tasks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="taskService">The service for managing todolist tasks.</param>
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        /// <summary>
        /// Retrieves all todo lists from the service by user id.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost(nameof(GetTasksByUserId))]
        public async Task<ActionResult<List<GetTasksModel>>> GetTasksByUserId([FromBody] FilterUserTaskModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new NullReferenceException();
            }

            var todoListItems = await this.taskService.GetTasksByUserId(int.Parse(userId), model);
            return this.Ok(todoListItems);
        }

        /// <summary>
        /// Retrieves all todo lists from the service.
        /// </summary>
        /// <param name="todoListId">Item Id Of TodoList.</param>
        /// <returns>A list of todo lists. The response is wrapped in an ActionResult for HTTP status code handling.</returns>
        [HttpGet("GetTasksByTodoListId/{todoListId}")]
        public async Task<ActionResult<List<GetTasksModel>>> GetTasksByTodoListId(int todoListId)
        {
            var todoListItems = await this.taskService.GetTasksByTodoListId(todoListId);
            return this.Ok(todoListItems);
        }

        /// <summary>
        /// Retrieves all todo lists from the service.
        /// </summary>
        /// <param name="itemId">Item Id Of TodoList.</param>
        /// <returns>A list of todo lists. The response is wrapped in an ActionResult for HTTP status code handling.</returns>
        [HttpGet("GetTasksById/{itemId}")]
        public async Task<ActionResult<GetTaskByIdModel>> GetTasksById(int itemId)
        {
            var todoListItems = await this.taskService.GetTaskById(itemId);
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
        public async Task<IActionResult> CreateTask(AddTaskModel todo)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new NullReferenceException();
            }

            todo.AddUserId(Convert.ToInt32(userId));

            await this.taskService.AddTask(todo);

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
        public async Task<IActionResult> DeleteTask(int itemId)
        {
            try
            {
                await this.taskService.RemoveTask(itemId);
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
        public async Task<IActionResult> UpdateTask(int itemId, [FromBody] AddTaskModel updatedItem)
        {
            if (updatedItem == null)
            {
                return this.BadRequest("Invalid request body.");
            }

            try
            {
                await this.taskService.UpdateTask(itemId, updatedItem);
                return this.Ok();
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
        /// <param name="taskStatus">The updated TodoItem information.</param>
        /// <returns>
        /// A NoContent result if the update is successful, BadRequest if the updatedItem is null,
        /// or NotFound if a TodoItem with the specified ID does not exist.
        /// </returns>
        [HttpPut("UpdateTaskStatus/{itemId}")]
        public async Task<IActionResult> UpdateTaskStatus(int itemId, [FromBody] TaskStatusType taskStatus)
        {
            try
            {
                await this.taskService.UpdateTaskStatus(itemId, taskStatus);
                return this.Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
