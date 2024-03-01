// <copyright file="TaskTags.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.WebApi.Models.Models
{
    /// <summary>
    /// Represents a tag associated with a task. Tags can be used to categorize or highlight specific characteristics of a task.
    /// </summary>
    public class TaskTags
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task tag.
        /// </summary>
        /// <value>The unique identifier of the task tag.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag text. This property represents a label or keyword associated with a task.
        /// </summary>
        /// <value>The text of the tag.</value>
        public string Tag { get; set; }
    }
}