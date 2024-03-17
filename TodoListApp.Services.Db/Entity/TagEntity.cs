// <copyright file="TagEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a tag associated with a task in the Todo List application.
    /// </summary>
    /// <remarks>
    /// Each tag can be linked to a specific task, allowing for categorization or labeling of tasks for better organization and searchability.
    /// </remarks>
    public class TagEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the tag.
        /// </summary>
        /// <value>
        /// The tag's unique identifier, typically used as the primary key in the database.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>
        /// The name is used to describe or label the tag, making it identifiable and searchable.
        /// </value>
        [Required]
        public string Name { get; set; }

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
