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
    }
}