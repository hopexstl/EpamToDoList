// <copyright file="TodoListModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApi.Models.Models
{
    /// <summary>
    /// Represents a single to-do item with a title.
    /// </summary>
    public class TodoListModel
    {
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
