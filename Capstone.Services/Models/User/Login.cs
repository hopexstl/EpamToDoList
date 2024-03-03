// <copyright file="Login.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Models.User
{
    /// <summary>
    /// Represents a single user with a email and password.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets the unique email for the user. This email is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique email of the user.</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the unique password for the user. This password is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique password of the user.</value>
        public string? Password { get; set; }
    }
}
