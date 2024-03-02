// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Interfaces
{
    using TodoList.Services.Models.User;

    /// <summary>
    /// User Interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously creates a new user in the system.
        /// </summary>
        /// <param name="item">The user object containing the details of the new user to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateUser(User item);

        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="GetUsers"/> objects.</returns>
        Task<List<GetUsers>> GetAllUsers();

        /// <summary>
        /// Asynchronously deletes a user from the system.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUser(int userId);

        /// <summary>
        /// Asynchronously updates the details of an existing user in the system.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be updated.</param>
        /// <param name="updatedItem">The user object containing the updated details of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateUser(int userId, User updatedItem);
    }
}
