// <copyright file="GetUsers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.User
{
    /// <summary>
    /// Represents a user in the system, providing key information that can be used for display purposes.
    /// </summary>
    public class GetUsers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsers"/> class.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="firstName">User First Name</param>
        /// <param name="lastName">User Last Name</param>
        /// <param name="email">User Email</param>
        public GetUsers(int id, string? firstName, string? lastName, string? email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the user. This identifier is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique identifier of the user.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first name for the user. This first name is typically used as the primary key in the database.
        /// </summary>
        /// <value>The first name of the user.</value>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name for the user. This last name is typically used as the primary key in the database.
        /// </summary>
        /// <value>The last name of the user.</value>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the unique email for the user. This email is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique email of the user.</value>
        public string? Email { get; set; }
    }
}
