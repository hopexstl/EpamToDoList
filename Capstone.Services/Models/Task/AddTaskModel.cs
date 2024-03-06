// <copyright file="AddTaskModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Task
{
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Represents a single to-do item with a title and a description.
    /// </summary>
    public class AddTaskModel
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

        /// <summary>
        /// Gets the identifier of the user who created the task.
        /// </summary>
        public int CreatedBy { get; private set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the task.
        /// </summary>
        /// <param name="userId">The Todo List item to be created. This parameter is received from the request body.</param>
        public void AddUserId(int userId)
        {
            this.CreatedBy = userId;
        }
    }
}
