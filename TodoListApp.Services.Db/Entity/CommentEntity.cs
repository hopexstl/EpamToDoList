// <copyright file="CommentEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the properties and behavior of a comment entity in the context of the application. A comment entity typically includes information such as the comment text, author, and the related task.
    /// </summary>
    public class CommentEntity
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
        [ForeignKey("Task")]
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task associated with a comment. This navigation property allows for accessing the task details from a comment entity.
        /// </summary>
        public TaskEntity Task { get; set; }
    }
}
