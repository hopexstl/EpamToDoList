// <copyright file="ICommentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Models.Comments;
    using TodoList.Services.Models.Task;

    /// <summary>
    /// Represents the contract for a service that manages comments.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Asynchronously adds a new comment.
        /// </summary>
        /// <param name="comment">The comment to add. This includes all necessary information about the comment such as the content, author, and associated post.</param>
        /// <remarks>
        /// This method is responsible for adding a comment to the underlying storage mechanism.
        /// It may involve validation and processing of the comment before it is added.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="comment"/> is null.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddCommentAsync(CommentForCreate comment);
    }
}
