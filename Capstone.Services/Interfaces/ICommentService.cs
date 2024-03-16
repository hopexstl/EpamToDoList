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

        /// <summary>
        /// Asynchronously deletes a comment identified by its ID.
        /// </summary>
        /// <param name="id">The ID of the comment to be deleted.</param>
        /// <returns>A task representing the asynchronous operation of deleting the comment.</returns>
        /// <remarks>
        /// This method attempts to delete the comment corresponding to the provided ID. If the comment does not exist,
        /// the implementation may throw a <see cref="KeyNotFoundException"/>.
        /// </remarks>
        /// <exception cref="KeyNotFoundException">Thrown when a comment with the specified ID is not found.</exception>
        Task DeleteCommentAsync(int id);

        /// <summary>
        /// Asynchronously updates an existing comment with new information.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to be updated.</param>
        /// <param name="comment">The model containing the updated information for the comment.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no comment with the specified ID exists.</exception>
        Task UpdateCommentAsync(int id, CommentForUpdate comment);
    }
}
