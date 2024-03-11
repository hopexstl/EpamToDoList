// <copyright file="TodoListDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.Services.Db.Services
{
    using Capstone.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Models;
    using TodoListApp.Services.Db.Entity;

    /// <summary>
    /// Provides services for managing todo items in a database.
    /// </summary>
    public class TodoListService : ITodoListService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListService"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the database.</param>
        public TodoListService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="userId">The ID of the todo item to be updated.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoList"/> models.</returns>
        public async Task<List<TodoList>> GetAllByUserId(int userId)
        {
            var todoList = await this.context!.TodoList!
                                                .Where(x => x.Tasks!.Any(x => x.TaskAssigneeId == userId))
                                                .Select(e => new TodoList(e.Id, e.Title, e.Description))
                                                .ToListAsync();

            return todoList;
        }

        /// <summary>
        /// Asynchronously removes a Todo item from the database based on the specified item identifier.
        /// </summary>
        /// /// <param name="item">The unique identifier of the Todo item to be added.</param>
        /// /// <returns>A task that represents the asynchronous Add operation.</returns>
        public async Task AddTodoItem(TodoList item)
        {
            var toDoListItem = new TodoListEntity(item.Title, item.Description);

            await this.context!.TodoList!.AddAsync(toDoListItem);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously removes a Todo item from the database based on the specified item identifier.
        /// </summary>
        /// <param name="itemId">The unique identifier of the Todo item to be removed.</param>
        /// <returns>A task that represents the asynchronous remove operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if a Todo item with the specified identifier is not found.</exception>
        public async Task RemoveTodoItem(int itemId)
        {
            var toDoListItem = await this.context!.TodoList!.FindAsync(itemId);

            if (toDoListItem != null)
            {
                this.context.TodoList.Remove(toDoListItem);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }

        /// <summary>
        /// Asynchronously updates an existing Todo item in the database with new values.
        /// </summary>
        /// <param name="itemId">The unique identifier of the Todo item to be updated.</param>
        /// <param name="updatedItem">The new values for the Todo item. The Id property is ignored if supplied.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if a Todo item with the specified identifier is not found.</exception>
        public async Task UpdateTodoItem(int itemId, TodoList updatedItem)
        {
            var toDoListItem = await this.context!.TodoList!.FindAsync(itemId);

            if (toDoListItem != null)
            {
                toDoListItem.Update(updatedItem.Title, updatedItem.Description);

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }
    }
}