// <copyright file="TaskForCreate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Task
{
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Represents a single to-do item with a title and a description.
    /// </summary>
    public class TaskForCreate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskForCreate"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="description">Description.</param>
        /// <param name="dueDate">Due Date.</param>
        /// <param name="status">Task Status.</param>
        /// <param name="createdDate">Create Date.</param>
        /// <param name="assignee">Assignee.</param>
        /// <param name="todoListId">Todo List Id.</param>
        /// <param name="createdBy">Created By.</param>
        public TaskForCreate(string title, string? description, DateTime createdDate, DateTime dueDate, TaskStatusType status, int assignee, int todoListId, int createdBy)
        {
            this.Title = title;
            this.Description = description;
            this.CreatedDate = createdDate;
            this.DueDate = dueDate;
            this.Status = status;
            this.Assignee = assignee;
            this.TodoListId = todoListId;
            this.CreatedBy = createdBy;
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
        /// Adds a user ID to the current context or collection. 
        /// </summary>
        /// <param name="v">The user ID to add. This should be a positive integer representing a unique identifier for a user.</param>
        /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
        public void AddUserId(int v)
        {
            throw new NotImplementedException();
        }
    }
}
