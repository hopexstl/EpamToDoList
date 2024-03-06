// <copyright file="TaskService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Db.Entity;
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
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="GetTasksModel"/> models.</returns>
        public async Task<GetTaskByIdModel> GetTaskById(int itemId)
        {
            var task = await this.context!.Tasks!
                .Where(x => x.Id == itemId)
                .Select(x => new GetTaskByIdModel(x.Title!, x.Description, x.CreatedDate, x.DueDate, x.TaskStatus))
                .FirstOrDefaultAsync();

            if (task == null)
            {
                throw new ArgumentNullException();
            }

            return task;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="userId">The unique identifier of the task by todolist id.</param>
        /// <param name="model">the unique model filtering to filter tasks.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="GetTasksModel"/> models.</returns>
        public async Task<List<GetTasksModel>> GetTasksByUserId(int userId, FilterUserTaskModel model)
        {
            var task = await this.context!.Tasks!
                .Where(x => x.TaskAssigneeId == userId)
                .Where(x => string.IsNullOrWhiteSpace(model.Title) || x.Title!.ToLower().Contains(model.Title.ToLower()))
                .Where(x => !model.Status.HasValue || x.TaskStatus.Equals((TaskStatusType)model.Status.Value))
                .Select(x => new GetTasksModel(x.Title!, x.CreatedDate, x.DueDate, x.TaskStatus))
                .ToListAsync();

            if (task == null)
            {
                throw new ArgumentNullException();
            }

            return task;
        }

        /// <summary>
        /// Asynchronously retrieves all todo lists from the database.
        /// </summary>
        /// <param name="todoListId">The unique identifier of the task by todolist id.</param>
        /// <remarks>
        /// This method fetches todo list entities from the database, converts them to the TodoList model,
        /// and returns a list of these models. Each model includes the Id and Title of the todo list.
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="GetTasksModel"/> models.</returns>
        public async Task<List<GetTasksModel>> GetTasksByTodoListId(int todoListId)
        {
            var task = await this.context!.Tasks!
                .Where(x => x.TodoListId == todoListId)
                .Select(x => new GetTasksModel(x.Title!, x.CreatedDate, x.DueDate, x.TaskStatus))
                .ToListAsync();

            if (task == null)
            {
                throw new ArgumentNullException();
            }

            return task;
        }

        /// <inheritdoc/>
        public async Task AddTask(AddTaskModel item)
        {
            var taskModel = new TaskModel(item.Title, item.Description, item.DueDate, item.Status, item.CreatedBy, item.Assignee, item.TodoListId);

            await this.context!.Tasks!.AddAsync(taskModel);
            await this.context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateTask(int itemId, AddTaskModel item)
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
