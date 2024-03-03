// <copyright file="FilterUserTaskModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Task
{
    /// <summary>
    /// Represents a filtering and sortering for user tasks.
    /// </summary>
    public class FilterUserTaskModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterUserTaskModel"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="createdDate">Created Date.</param>
        /// <param name="dueDate">Due Date.</param>
        /// <param name="taskStatus">Task Status.</param>
        public FilterUserTaskModel(string? title, byte? taskStatus)
        {
            this.Title = title;
            this.TaskStatus = taskStatus;
        }

        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the current status of the task, represented as a <see cref="TaskStatus"/> enum value.
        /// </summary>
        public byte? TaskStatus { get; set; }
    }
}
