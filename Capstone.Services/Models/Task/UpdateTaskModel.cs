// <copyright file="UpdateTaskModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Task
{
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Updates Task Model.
    /// </summary>
    public class UpdateTaskModel
    {
        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the task.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the due date and time by which the task should be completed.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the current status of the task, represented as a <see cref="TaskStatusType"/> enum value.
        /// </summary>
        public TaskStatusType Status { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom the task is assigned.
        /// This property acts as a foreign key referencing the UserEntity.
        /// </summary>
        public int Assignee { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom the task is assigned.
        /// This property acts as a foreign key referencing the UserEntity.
        /// </summary>
        public int TodoListId { get; set; }
    }
}
