// <copyright file="Task.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.WebApi.Models.Models
{
    /// <summary>
    /// Represents a task in the Todo List application, including details about the task, its status, and assignment.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the task.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the task was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the due date and time by which the task should be completed.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the current status of the task, represented as a <see cref="TaskStatus"/> enum value.
        /// </summary>
        public TaskStatus TaskStatus { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the task.
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom the task is assigned.
        /// </summary>
        public int TaskAssignee { get; set; }
    }
}