// <copyright file="TaskService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Db.Entity;
    using TodoList.Services.Db.Exceptions;
    using TodoList.Services.Db.Mappings;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.Task;
    using TodoListApp.Services.Db;
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Provides services for managing todo items in a database.
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the database.</param>
        public TaskService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="itemId">The unique identifier of the task by todolist id.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> models.</returns>
        public async Task<TaskForCreate> GetTaskById(int itemId)
        {
            var task = await this.context!.Tasks!
                .Where(x => x.Id == itemId)
                .Select(x => new TaskForCreate(x.Title!, x.Description, x.CreatedDate, x.DueDate, x.TaskStatus, x.TaskAssigneeId, x.CreatedById, x.TodoListId))
                .FirstOrDefaultAsync();

            if (task == null)
            {
                throw new KeyNotFoundException();
            }

            return task;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="userId">The unique identifier of the task by todolist id.</param>
        /// <param name="filter">the unique model filtering to filter tasks.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> models.</returns>
        public async Task<List<TodoTask>> GetTasksByUserId(int userId, FilterUserTaskModel filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var query = this.context.Tasks.Where(x => x.TaskAssigneeId == userId);

            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.TaskStatus == (TaskStatusType)filter.Status.Value);
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x => x.Title.Contains(filter.Title));
            }

            var tasks = await query.Select(x => new TodoTask(x.Title, x.CreatedDate, x.DueDate, x.TaskStatus))
                .ToListAsync();

            return tasks;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="todoListId">The unique identifier of the task by todolist id.</param>
        /// <param name="searchQuery">Search Query.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="TodoTask"/> models.</returns>
        public async Task<List<TodoTask>> GetTasksByTodoListId(int? todoListId, string? searchQuery)
        {
            var tasks = this.context.Tasks.AsQueryable();

            if (todoListId.HasValue)
            {
                tasks = tasks.Where(x => x.TodoListId == todoListId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                tasks = tasks.Where(x => x.Title.Contains(searchQuery));
            }

            return await tasks
                .Select(x => new TodoTask(x.Title!, x.CreatedDate, x.DueDate, x.TaskStatus))
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<TodoTask>> GetTasksByTitle(int userId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));
            }

            var tasks = await this.context.Tasks
                .Where(x => x.TaskAssigneeId == userId && EF.Functions.Like(x.Title, $"%{title}%"))
                .Select(x => new TodoTask(x.Title, x.CreatedDate, x.DueDate, x.TaskStatus))
                .ToListAsync();

            return tasks;
        }

        /// <inheritdoc/>
        public async Task AddTask(TaskForCreate item)
        {
            var taskEntity = new TaskEntity(item.Title, item.Description, item.DueDate, item.Status, item.CreatedBy, item.Assignee, item.TodoListId);

            await this.context!.Tasks!.AddAsync(taskEntity);
            await this.context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateTask(int itemId, TaskForCreate item)
        {
            var task = await this.context!.Tasks!.FindAsync(itemId);

            if (task != null)
            {
                task.Update(item.Title, item.Description, item.DueDate, item.Status, item.Assignee);

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }

        /// <inheritdoc/>
        public async Task UpdateTaskStatus(int itemId, TaskStatusType taskStatus)
        {
            var task = await this.context!.Tasks!.FindAsync(itemId);

            if (task != null)
            {
                task.UpdateStatus(taskStatus);

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }

        /// <inheritdoc/>
        public async Task RemoveTask(int itemId)
        {
            var task = await this.context!.Tasks!.FindAsync(itemId);

            if (task != null)
            {
                this.context.Tasks.Remove(task);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {itemId} not found.");
            }
        }
    }
}
