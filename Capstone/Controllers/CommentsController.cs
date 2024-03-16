// <copyright file="CommentsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comment commentModel)
        {
            await this.commentService.AddCommentAsync(commentModel);
            return Ok();
        }
    }
}
