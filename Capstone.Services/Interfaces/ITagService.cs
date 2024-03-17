// <copyright file="ITagService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Models.Tags;

    /// <summary>
    /// Defines the contract for a service that manages tags associated with tasks.
    /// </summary>
    /// <remarks>
    /// This interface provides functionality to add and manage tags within the application,
    /// enabling the categorization or labeling of tasks for better organization and searchability.
    /// </remarks>
    public interface ITagService
    {
        /// <summary>
        /// Asynchronously adds a tag to a specified task.
        /// </summary>
        /// <param name="taskId">The identifier of the task to which the tag will be added.</param>
        /// <param name="tagName">The name of the tag to be added to the task.</param>
        /// <remarks>
        /// This method is responsible for ensuring that the specified tag is added to the given task.
        /// If the tag does not already exist, it may create a new tag before associating it with the task.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddTagToTaskAsync(int taskId, string tagName);

        /// <summary>
        /// Asynchronously removes a tag from a specified task.
        /// </summary>
        /// <param name="taskId">The identifier of the task from which the tag will be removed.</param>
        /// <param name="tagName">The name of the tag to be removed from the task.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task RemoveTagFromTaskAsync(int taskId, string tagName);

        /// <summary>
        /// Asynchronously retrieves all tags.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing an enumerable of all tags.</returns>
        Task<IEnumerable<Tags>> GetAllTagsAsync();
    }
}
