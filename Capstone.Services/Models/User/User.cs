// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.User
{
    /// <summary>
    /// Represents a single user with a first name, last name and email.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets first name for the user. This first name is typically used as the primary key in the database.
        /// </summary>
        /// <value>The first name of the user.</value>
        public string FirstName { get; set; }

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

        /// <summary>
        /// Gets or sets the unique password for the user. This password is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique password of the user.</value>
        public string Password { get; set; }
    }
}
