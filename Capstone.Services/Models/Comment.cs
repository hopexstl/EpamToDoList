// <copyright file="Comment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a comment made on a task.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the comment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        /// <value>
        /// The content is a string that contains the actual comment text.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the task this comment is associated with.
        /// </summary>
        /// <value>
        /// The TaskId is an integer that links the comment to a specific task.
        /// </value>
        public int TaskId { get; set; }
    }
}
