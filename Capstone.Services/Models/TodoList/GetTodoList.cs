// <copyright file="GetTodoList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.TodoList
{
    /// <summary>
    /// Represents a single to-do item with a title and a description.
    /// </summary>
    public class GetTodoList
    {
        /// <summary>
        /// Gets or sets the unique identifier for this entity.
        /// </summary>
        /// <value>The unique identifier, typically used as a primary key in the database.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the to-do item.
        /// </summary>
        /// <value>The title of the to-do item.</value>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the to-do item.
        /// </summary>
        /// <value>The description of the to-do item.</value>
        public string? Description { get; set; }
    }
}
