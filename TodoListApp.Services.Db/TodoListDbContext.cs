// <copyright file="TodoListDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.Services.Db
{
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Db.Entity;
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
        public DbSet<TodoListModel>? TodoList { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> representing the Task in the database.
        /// This property can be used to query and save instances of Task entities.
        /// </summary>
        public DbSet<TaskModel>? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> representing the User in the database.
        /// This property can be used to query and save instances of User entities.
        /// </summary>
        public DbSet<UserModel>? Users { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the foreign key relationship between Tasks and Users
            modelBuilder.Entity<TaskModel>()
                .HasOne<UserModel>() // Assuming TaskModel has a navigation property to UserModel. Adjust if necessary.
                .WithMany() // Assuming UserModel has a collection navigation property to TaskModel. Adjust if necessary.
                .HasForeignKey(t => t.TaskAssigneeId) // Adjust the name if necessary.
                .OnDelete(DeleteBehavior.Restrict); // This prevents cascade delete. Use DeleteBehavior.SetNull if you want to set the foreign key to null instead.
        }
    }
}
