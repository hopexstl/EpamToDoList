// <copyright file="CommentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.Comments;
    using TodoListApp.Services.Db;

    /// <summary>
    /// Provides services for managing comments in the application.
    /// </summary>
    /// <remarks>
    /// The CommentService class is responsible for all comment-related operations, such as adding new comments
    /// to the database. It interacts with the application's data context to perform these operations.
    /// </remarks>
    public class CommentService : ICommentService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class with a specified database context.
        /// </summary>
        /// <param name="context">The database context used for comment operations.</param>
        /// <remarks>
        /// This constructor injects the TodoListDbContext to be used for data operations related to comments.
        /// </remarks>
        public CommentService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously adds a new comment to the database.
        /// </summary>
        /// <param name="commentDto">The data transfer object containing the information needed to create a new comment.</param>
        /// <remarks>
        /// This method converts the provided CommentForCreate DTO into a Comment entity, adds it to the database context,
        /// and then saves the changes to the database asynchronously.
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation, indicating the method has completed without returning any value.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="commentDto"/> is null.</exception>
        public async Task AddCommentAsync(CommentForCreate commentDto)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                TaskId = commentDto.TaskId,
            };

            this.context.Comments.Add(comment);

            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously deletes a comment by its unique identifier.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous delete operation. The task completion signifies that the comment
        /// has been deleted from the database.
        /// </returns>
        /// <param name="commentId">The unique identifier of the comment to delete.</param>
        /// <remarks>
        /// This method searches for a comment by its ID in the database. If the comment is found, it is removed from the database.
        /// If the comment with the specified ID does not exist, a <see cref="KeyNotFoundException"/> is thrown.
        /// </remarks>
        /// <exception cref="KeyNotFoundException">Thrown when a comment with the specified ID cannot be found in the database.</exception>
        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await this.context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                this.context.Comments.Remove(comment);

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Comment not found");
            }
        }

        /// <summary>
        /// Asynchronously updates an existing comment with new information.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to update.</param>
        /// <param name="commentUpdateModel">The model containing the updated information for the comment.</param>
        /// <remarks>
        /// This method first attempts to find a comment by its ID. If found, it updates the comment's properties with the values from the <paramref name="commentUpdateModel"/>.
        /// The changes are then saved to the database.
        /// If no comment with the specified ID exists, a <see cref="KeyNotFoundException"/> is thrown.
        /// </remarks>
        /// <exception cref="KeyNotFoundException">Thrown when no comment with the specified ID can be found.</exception>
        /// <returns>A task that represents the asynchronous operation, containing no return value.</returns>
        public async Task UpdateCommentAsync(int id, CommentForUpdate commentUpdateModel)
        {
            var comment = await this.context.Comments.FindAsync(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }

            comment.Content = commentUpdateModel.Content;

            await this.context.SaveChangesAsync();
        }
    }
}
