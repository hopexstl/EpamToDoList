// <copyright file="CommentForCreate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoListApp.WebApi.Models.Enum;

    /// <summary>
    /// Represents a comment create on a task.
    /// </summary>
    public class CommentForCreate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentForCreate"/> class.
        /// </summary>
        /// <param name="content">The content is a string that contains the actual comment text.</param>
        /// <param name="taskId">The TaskId is an integer that links the comment to a specific task.</param>
        public CommentForCreate(string content, int taskId)
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
