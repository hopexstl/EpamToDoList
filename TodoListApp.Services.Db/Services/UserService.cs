// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using TodoList.Services.Db.Entity;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models.User;
    using TodoListApp.Services.Db;

    /// <summary>
    /// Provides services for user management including creating, updating, deleting, and retrieving user information.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly TodoListDbContext context;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// This constructor injects the dependencies required for the service to interact with the database and access application settings.
        /// </summary>
        /// <param name="context">The database context used for user management operations. This context is responsible for interacting with the database to perform CRUD operations on user data.</param>
        /// <param name="configuration">The configuration interface used to access application settings, such as connection strings or other configuration parameters that may be required by the service.</param>
        public UserService(TodoListDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Asynchronously creates a new user in the database.
        /// </summary>
        /// <param name="item">The user details to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateUser(User item)
        {
            var emailExists = await this.context.Users!.AnyAsync(x => x.Email == item.Email);
            if (emailExists)
            {
                throw new Exception("User with this email already exists");
            }

            this.CreatePasswordHash(item.Password!, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new UserModel(item.FirstName, item.LastName, item.Email, passwordHash, passwordSalt);
            await this.context!.Users!.AddAsync(user);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously logins the user.
        /// </summary>
        /// <param name="item">The user log on.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<string> Login(Login item)
        {
            var user = await this.context.Users!.FirstOrDefaultAsync(x => x.Email == item.Email);
            if (user == null)
            {
                throw new Exception("User with this email doesn't exist");
            }

            if (!this.VerifyPasswordHash(item.Password!, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Password is incorrect");
            }

            string token = this.CreateToken(user);
            return await Task.FromResult(token);
        }

        /// <summary>
        /// Asynchronously retrieves all users from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of users.</returns>
        public async Task<List<GetUsers>> GetAllUsers()
        {
            var users = await this.context!.Users!.ToListAsync();

            var usersReturnModel = users.Select(e => new GetUsers(e.Id, e.FirstName, e.LastName, e.Email)).ToList();

            return usersReturnModel;
        }

        /// <summary>
        /// Asynchronously deletes a user from the database by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when a user with the specified ID was not found.</exception>
        public async Task DeleteUser(int userId)
        {
            var user = await this.context!.Users!.FindAsync(userId);

            if (user != null)
            {
                this.context.Users.Remove(user);
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
            var user = await this.context!.Users!.FindAsync(userId);

            if (user != null)
            {
                user.Update(updatedItem.FirstName, updatedItem.LastName, updatedItem.Email);

                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Todo item with Id {userId} not found.");
            }
        }

        /// <summary>
        /// Asynchronously creates a user's passwordhash and passwordsalt in the database.
        /// </summary>
        /// <param name="password">The unique identifier of the user password.</param>
        /// <param name="passwordHash">The unique identifier of the user passwordHash.</param>
        /// <param name="passwordSalt">The unique identifier of the user passwordSalt.</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Asynchronously verifies a user's passwordhash and passwordsalt.
        /// </summary>
        /// <param name="password">The unique identifier of the user password.</param>
        /// <param name="passwordHash">The unique identifier of the user passwordHash.</param>
        /// <param name="passwordSalt">The unique identifier of the user passwordSalt.</param>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// Asynchronously creates JwtToken for user.
        /// </summary>
        /// <param name="user">The unique user.</param>
        private string CreateToken(UserModel user)
        {
            List<Claim> claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() !),
                new Claim(ClaimTypes.Email, user.Email !),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this.configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claim,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
