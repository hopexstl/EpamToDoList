// <copyright file="TodoList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApi.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a single to-do item with a title.
    /// </summary>
    public class TodoList
    {
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

        public TodoList()
        {
        }

        public TodoList(int id, string title, string? description)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }
    }
}
