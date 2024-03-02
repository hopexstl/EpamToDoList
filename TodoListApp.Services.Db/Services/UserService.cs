// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using Microsoft.EntityFrameworkCore;
    using TodoList.Services.Db.Entity;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.TodoList;
    using TodoList.Services.Models.User;
    using TodoListApp.Services.Db;

    /// <summary>
    /// Provides services for user management including creating, updating, deleting, and retrieving user information.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly TodoListDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The database context used for user management operations.</param>
        public UserService(TodoListDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously creates a new user in the database.
        /// </summary>
        /// <param name="item">The user details to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateUser(User item)
        {
            // needs email check if it exists and password
            var entity = new UserEntity
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
            };
            await this.context!.User!.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously retrieves all users from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of users.</returns>
        public async Task<List<GetUsers>> GetAllUsers()
        {
            var entities = await this.context!.User!.ToListAsync();
            var models = entities.Select(e => new GetUsers
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
            }).ToList();

            return models;
        }

        /// <summary>
        /// Asynchronously deletes a user from the database by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when a user with the specified ID was not found.</exception>
        public async Task DeleteUser(int userId)
        {
            var entity = await this.context!.User!.FindAsync(userId);

            if (entity != null)
            {
                this.context.User.Remove(entity);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {userId} not found.");
            }
        }

        /// <summary>
        /// Asynchronously updates a user's details in the database.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be updated.</param>
        /// <param name="updatedItem">The new details of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when a user with the specified ID was not found.</exception>
        public async Task UpdateUser(int userId, User updatedItem)
        {
            var entity = await this.context!.User!.FindAsync(userId);

            if (entity != null)
            {
                entity.FirstName = updatedItem.FirstName;
                entity.LastName = updatedItem.LastName;
                entity.Email = updatedItem.Email;

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {userId} not found.");
            }
        }
    }
}
