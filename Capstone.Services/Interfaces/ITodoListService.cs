// <copyright file="ITodoListService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Services.Interfaces
{
    using TodoListApp.Services.Models;

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
        Task AddTodoItem(TodoList item);
    }
}