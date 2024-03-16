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
    }
}
