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

        /// <summary>
        /// Updates an existing comment with new information.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to update.</param>
        /// <param name="commentUpdateModel">The updated information for the comment.</param>
        /// <returns>
        /// Returns a <see cref="NoContentResult"/> if the update is successful, indicating the request has been fulfilled and there's nothing to return.
        /// Returns a <see cref="NotFoundResult"/> if no comment with the specified ID exists.
        /// </returns>
        /// <remarks>
        /// This method receives the ID of a comment and a model containing the updated information. It then calls the service layer to apply these updates.
        /// If the comment with the specified ID does not exist, a <see cref="KeyNotFoundException"/> is thrown by the service layer, and a 404 Not Found response is returned.
        /// </remarks>
        /// <exception cref="KeyNotFoundException">Thrown when no comment with the specified ID exists.</exception>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentForUpdate commentUpdateModel)
        {
            try
            {
                await this.commentService.UpdateCommentAsync(id, commentUpdateModel);
                return this.NoContent();
            }
            catch (KeyNotFoundException)
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Deletes a comment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to be deleted.</param>
        /// <remarks>
        /// This method attempts to delete a comment from the database. If the comment with the specified ID exists, it will be removed.
        /// If the comment cannot be found, the method responds with a 404 Not Found status code.
        /// </remarks>
        /// <returns>
        /// A <see cref="NoContentResult"/> if the comment was successfully deleted, indicating that the server has successfully fulfilled
        /// the request and that there is no additional content to send in the response payload body.
        /// A <see cref="NotFoundResult"/> is returned if a comment with the specified ID was not found.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                await this.commentService.DeleteCommentAsync(id);
                return this.NoContent();
            }
            catch (KeyNotFoundException)
            {
                return this.NotFound();
            }
        }
    }
}
