// <copyright file="TagsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Db.Entity;
using TodoList.Services.Interfaces;
using TodoList.Services.Models.Tags;

namespace TodoList.WebApi.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to tags, providing endpoints for managing tags associated with tasks.
    /// </summary>
    /// <remarks>
    /// The TagsController responds to HTTP requests that involve operations on tags,
    /// such as adding a new tag to a specific task.
    /// </remarks>
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagsController"/> class with a tag service.
        /// </summary>
        /// <param name="tagService">The service for managing tags.</param>
        /// <remarks>
        /// This constructor injects an ITagService instance for handling tag-related operations.
        /// </remarks>
        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>An IActionResult containing the list of all tags.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tags>>> GetAllTags()
        {
            var tags = await this.tagService.GetAllTagsAsync();
            return this.Ok(tags);
        }

        /// <summary>
        /// Adds a new tag with the specified name to the task identified by the given task ID.
        /// </summary>
        /// <param name="taskId">The ID of the task to which the tag will be added.</param>
        /// <param name="tagName">The name of the tag to add to the task.</param>
        /// <returns>An IActionResult that represents the result of the operation, typically an HTTP 200 OK status on success.</returns>
        /// <remarks>
        /// This POST action receives a task ID and a tag name in the request body,
        /// and uses the tag service to associate the specified tag with the given task.
        /// </remarks>
        [HttpPost("{taskId}/tags")]
        public async Task<IActionResult> AddTagToTask(int taskId, [FromBody] string tagName)
        {
            await this.tagService.AddTagToTaskAsync(taskId, tagName);
            return this.Ok();
        }

        /// <summary>
        /// Removes the specified tag from the task identified by the given task ID.
        /// </summary>
        /// <param name="taskId">The ID of the task from which the tag will be removed.</param>
        /// <param name="tagName">The name of the tag to be removed.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete("{taskId}/tags/{tagName}")]
        public async Task<IActionResult> RemoveTagFromTask(int taskId, string tagName)
        {
            await this.tagService.RemoveTagFromTaskAsync(taskId, tagName);
            return this.NoContent();
        }
    }
}
