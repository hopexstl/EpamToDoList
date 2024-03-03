// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.User;

    /// <summary>
    /// Controller for handling user-related operations in the TodoList Web API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service dependency.</param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="user">The user details to be added.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the create operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await this.userService.CreateUser(user);
            return this.NoContent();
        }

        /// <summary>
        /// login user in the system.
        /// </summary>
        /// <param name="user">The user details to be added.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the create operation.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(Login user)
        {
            var login = await this.userService.Login(user);
            return this.Ok(login);
        }

        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> containing a list of users.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GetUsers>>> GetAllUsers()
        {
            var todoLists = await this.userService.GetAllUsers();
            return this.Ok(todoLists);
        }

        /// <summary>
        /// Deletes a specified user by their unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation.</returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await this.userService.DeleteUser(userId);
                return this.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedItem">The new details for the user.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the update operation.</returns>
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User updatedItem)
        {
            if (updatedItem == null)
            {
                return this.BadRequest("Invalid request body.");
            }

            try
            {
                await this.userService.UpdateUser(userId, updatedItem);
                return this.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
