// <copyright file="CommentForUpdate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the data model used for updating an existing comment.
    /// </summary>
    /// <remarks>
    /// This class is used to encapsulate the properties that can be updated for a comment.
    /// Only the properties defined in this class can be updated, ensuring controlled updates
    /// and encapsulation of the update logic.
    /// </remarks>
    public class CommentForUpdate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentForUpdate"/> class.
        /// </summary>
        /// <param name="content">The content is a string that contains the actual comment text.</param>
        /// <param name="taskId">The TaskId is an integer that links the comment to a specific task.</param>
        public CommentForUpdate(string content, int taskId)
        {
            this.Content = content;
            this.TaskId = taskId;
        }

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
