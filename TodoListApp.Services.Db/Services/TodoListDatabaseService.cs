// <copyright file="TodoListDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.Services.Db.Services
{
    using Capstone.Services.Interfaces;
    using TodoListApp.Services.Db.Entity;
    using TodoListApp.Services.Models;

    /// <summary>
    /// Provides services for managing todo items in a database.
    /// </summary>
    public class TodoListDatabaseService : ITodoListService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListDatabaseService"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the database.</param>
        public TodoListDatabaseService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task AddTodoItem(TodoList item)
        {
            var entity = new TodoListEntity
            {
                Title = item.Title,
            };
            await this.context.TodoList.AddAsync(entity);
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
            var entity = await this.context.TodoList.FindAsync(itemId);

            if (entity != null)
            {
                this.context.TodoList.Remove(entity);
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
            var entity = await this.context.TodoList.FindAsync(itemId);

            if (entity != null)
            {
                entity.Title = updatedItem.Title;

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }
    }
}