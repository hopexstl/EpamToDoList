// <copyright file="ITaskService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Interfaces
{
    using TodoList.Services.Models.Task;
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Defines the contract for a service that manages task list items.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Adds a new task item to the task list.
        /// </summary>
        /// <param name="item">The task item to add. The item should contain all necessary information such as title and, optionally, a description.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task AddTask(TaskForCreate item);

        /// <summary>
        /// Removes a task item from the database.
        /// </summary>
        /// <param name="itemId">The ID of the task item to be removed.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when a task item with the specified ID is not found in the database.
        /// </exception>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task RemoveTask(int itemId);

        /// <summary>
        /// Updates an existing task item in the database with new values.
        /// </summary>
        /// <param name="itemId">The ID of the task item to be updated.</param>
        /// <param name="item">The updated task item object containing the new values.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when a task item with the specified ID is not found in the database.
        /// </exception>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task UpdateTask(int itemId, TaskForCreate item);

        /// <summary>
        /// Updates an existing task item in the database with new values.
        /// </summary>
        /// <param name="itemId">The ID of the task item to be updated.</param>
        /// <param name="taskStatus">The updated task item object containing the new values.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when a task item with the specified ID is not found in the database.
        /// </exception>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task UpdateTaskStatus(int itemId, TaskStatusType taskStatus);

        /// <summary>
        /// Asynchronously retrieves all task lists by todolist Id.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> instances.</returns>
        /// <param name="todoListId">The ID of the task item task to get.</param>
        /// <param name="searchQuery">Search Query.</param>
        Task<List<TodoTask>> GetTasksByTodoListId(int? todoListId, string? searchQuery);

        /// <summary>
        /// Asynchronously retrieves all task lists by todolist Id.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> instances.</returns>
        /// <param name="userId">The ID of the user for tasks to get.</param>
        /// <param name="model">The updated task item object containing the new values.</param>
        Task<List<TodoTask>> GetTasksByUserId(int userId, FilterUserTaskModel model);

        /// <summary>
        /// Asynchronously retrieves all task lists by todolist Id.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> instances.</returns>
        /// <param name="itemId">The ID of the task item task to get.</param>
        Task<TaskForCreate> GetTaskById(int itemId);

        /// <summary>
        /// Retrieves tasks for a specific user where the task title contains the specified search text.
        /// </summary>
        /// <param name="userId">The ID of the user whose tasks are to be retrieved.</param>
        /// <param name="title">The text to search for within the task titles.</param>
        /// <returns>A list of tasks that match the search criteria.</returns>
        Task<List<TodoTask>> GetTasksByTitle(int userId, string title);
    }
}
