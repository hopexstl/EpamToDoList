// <copyright file="TodoListDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.Services.Db
{
    using Microsoft.EntityFrameworkCore;
    using TodoListApp.Services.Db.Entity;

    /// <summary>
    /// Represents the database context for the Todo List application, providing access to the Todo List entities.
    /// </summary>
    public class TodoListDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListDbContext"/> class using the specified options.
        /// The options are typically configured in the application's startup class and can include settings such as the database provider, connection string, etc.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> representing the Todo List in the database.
        /// This property can be used to query and save instances of Todo List entities.
        /// </summary>
        public DbSet<TodoListEntity> TodoList { get; set; }
    }
}
