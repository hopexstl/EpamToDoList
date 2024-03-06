// <copyright file="GetTaskByIdModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Task
{
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Represents a single to-do item with a title and a description.
    /// </summary>
    public class GetTaskByIdModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaskByIdModel"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="description">Description.</param>
        /// <param name="createdDate">Created Date.</param>
        /// <param name="dueDate">Due Date.</param>
        /// <param name="status">Task Status.</param>
        public GetTaskByIdModel(string title, string? description, DateTime createdDate, DateTime dueDate, TaskStatusType status)
        {
            this.Title = title;
            this.Description = description;
            this.CreatedDate = createdDate;
            this.DueDate = dueDate;
            this.Status = status;
            this.IsOverdue = dueDate > DateTime.Now ? true : false;
        }

        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; }

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
        /// Gets or sets the current status of the task, represented as a <see cref="TaskStatusType"/> enum value.
        /// </summary>
        public TaskStatusType Status { get; set; }

        /// <summary>
        /// Gets or sets a assignee email of the task.
        /// </summary>
        public string? AssigneeEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether task is overdue.
        /// </summary>
        public bool IsOverdue { get; set; }
    }
}
