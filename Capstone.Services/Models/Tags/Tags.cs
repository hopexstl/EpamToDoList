// <copyright file="Tags.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Tags
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a tag that can be associated with a task.
    /// </summary>
    /// <remarks>
    /// Tags provide a way to categorize or label tasks, making them easier to organize and search.
    /// Each tag is associated with a specific task, indicating a one-to-many relationship between tasks and tags.
    /// </remarks>
    public class Tags
    {
        /// <summary>
        /// Gets or sets the unique identifier for the tag.
        /// </summary>
        /// <value>
        /// The tag's unique identifier, typically used as the primary key in a database.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>
        /// The name of the tag, used for categorization or labeling of tasks.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the task this comment is associated with.
        /// </summary>
        /// <value>
        /// The TaskId is an integer that links the comment to a specific task.
        /// </value>
        public int TaskId { get; set; }
    }
}
