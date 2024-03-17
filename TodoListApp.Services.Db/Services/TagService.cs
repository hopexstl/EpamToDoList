// <copyright file="TagService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Db.Entity;
    using TodoList.Services.Db.Exceptions;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.Tags;
    using TodoListApp.Services.Db;

    /// <summary>
    /// Provides services for managing tags associated with tasks in the Todo List application.
    /// </summary>
    /// <remarks>
    /// The TagService class offers functionality to add new tags to tasks and manage existing tags,
    /// enabling the categorization or labeling of tasks for better organization and searchability.
    /// </remarks>
    public class TagService : ITagService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagService"/> class with a specified database context.
        /// </summary>
        /// <param name="context">The database context used for tag and task operations.</param>
        /// <remarks>
        /// This constructor injects the TodoListDbContext to be used for data operations related to tags and tasks,
        /// facilitating interactions with the underlying database.
        /// </remarks>
        public TagService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously adds a new tag with the specified name to a task identified by the given task ID.
        /// </summary>
        /// <param name="taskId">The identifier of the task to which the tag will be added.</param>
        /// <param name="tagName">The name of the tag to be added.</param>
        /// <remarks>
        /// This method creates a new tag entity with the provided name and associates it with the specified task.
        /// If the specified task does not exist, an EntityNotFoundException is thrown.
        /// </remarks>
        /// <exception cref="EntityNotFoundException">Thrown if no task with the specified ID exists.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, indicating that the tag has been successfully added to the task.</returns>
        public async Task AddTagToTaskAsync(int taskId, string tagName)
        {
            var task = await this.context.Tasks.FindAsync(taskId);
            if (task == null)
            {
                throw new EntityNotFoundException($"Task with ID {taskId} not found.");
            }

            var tag = new TagEntity { Name = tagName, TaskId = taskId };
            this.context.Tags.Add(tag);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously removes a tag from the task identified by the given task ID.
        /// </summary>
        /// <param name="taskId">The ID of the task from which the tag will be removed.</param>
        /// <param name="tagName">The name of the tag to be removed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, indicating that the tag has been successfully removed from the task.</returns>
        public async Task RemoveTagFromTaskAsync(int taskId, string tagName)
        {
            var tag = await this.context.Tags.FirstOrDefaultAsync(t => t.Name == tagName && t.TaskId == taskId);
            if (tag == null)
            {
                throw new EntityNotFoundException($"Tag with name {tagName} not found for task with ID {taskId}.");
            }

            this.context.Tags.Remove(tag);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously retrieves all tags from the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing an enumerable of all <see cref="TagEntity"/> instances.</returns>
        public async Task<IEnumerable<Tags>> GetAllTagsAsync()
        {
            var tagEntities = await this.context.Tags.ToListAsync();
            var tagsList = tagEntities.Select(te => new Tags
            {
                Id = te.Id,
                Name = te.Name,
            }).ToList();

            return tagsList;
        }
    }
}
