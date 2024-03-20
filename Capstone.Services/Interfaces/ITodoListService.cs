// <copyright file="ITodoListService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Services.Interfaces
{
    using TodoList.Services.Models.TodoList;

    /// <summary>
    /// Defines the contract for a service that manages todo list items.
    /// </summary>
    public interface ITodoListService
    {
        /// <summary>
        /// Adds a new todo item to the todo list.
        /// </summary>
        /// <param name="item">The todo item to add. The item should contain all necessary information such as title and, optionally, a description.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task AddTodoItem(Todo item);

        /// <summary>
        /// Removes a todo item from the database.
        /// </summary>
        /// <param name="itemId">The ID of the todo item to be removed.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when a todo item with the specified ID is not found in the database.
        /// </exception>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task RemoveTodoItem(int itemId);

        /// <summary>
        /// Updates an existing todo item in the database with new values.
        /// </summary>
        /// <param name="itemId">The ID of the todo item to be updated.</param>
        /// <param name="item">The updated todo item object containing the new values.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when a todo item with the specified ID is not found in the database.
        /// </exception>
        /// <returns>A task that represents the asynchronous operation. The task result contains no return value.</returns>
        Task UpdateTodoItem(int itemId, Todo item);

        /// <summary>
        /// Asynchronously retrieves all todo lists.
        /// </summary>
        /// <param name="userId">The ID of the todo item to be updated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Todo"/> instances.</returns>
        Task<List<GetTodoList>> GetAllTodoListsByUserId(int userId);
    }
}