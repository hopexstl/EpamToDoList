// <copyright file="TodoList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models
{
    /// <summary>
    /// Represents a single to-do item with a title.
    /// </summary>
    public class TodoList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoList"/> class with the specified ID, title, and an optional description.
        /// </summary>
        /// <param name="id">The unique identifier for the todo list.</param>
        /// <param name="title">The title of the todo list. This field is required.</param>
        /// <param name="description">An optional description for the todo list. This field can be null.</param>
        /// <remarks>
        /// This constructor sets up a new todo list with the provided details. The ID should be unique to ensure that each todo list can be accurately identified.
        /// The title provides a concise summary of what the todo list encompasses, while the optional description allows for a more detailed explanation of the todo list's purpose or contents.
        /// </remarks>
        public TodoList(int id, string title, string? description)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the Id of the Todo item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the to-do item.
        /// </summary>
        /// <value>The title of the to-do item.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the to-do item.
        /// </summary>
        /// <value>The description of the to-do item.</value>
        public string? Description { get; set; }
    }
}
