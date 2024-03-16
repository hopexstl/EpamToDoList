// <copyright file="CommentsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using TodoList.Services.Models.Comments;

namespace TodoList.WebApi.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to comments.
    /// </summary>
    /// <remarks>
    /// The CommentsController provides an API endpoint for creating and managing comments in the application.
    /// It interacts with the ICommentService to perform operations on comments.
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsController"/> class.
        /// </summary>
        /// <param name="commentService">The service for managing comments.</param>
        /// <remarks>
        /// This constructor injects an instance of ICommentService to be used for comment operations.
        /// </remarks>
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        /// <summary>
        /// Adds a new comment.
        /// </summary>
        /// <param name="comment">The comment data used for creation.</param>
        /// <returns>An IActionResult that represents the result of the operation.</returns>
        /// <remarks>
        /// This POST endpoint receives comment data, uses the comment service to add the comment,
        /// and returns an HTTP 200 OK status code upon successful addition.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentForCreate comment)
        {
            await this.commentService.AddCommentAsync(comment);

            return this.Ok();
        }
    }
}
