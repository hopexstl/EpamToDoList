// <copyright file="UserEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Entity
{
    /// <summary>
    /// Represents a user within the application. This class can be expanded to include additional user-related properties such as name, email, etc.
    /// </summary>
    public class UserEntity
    {
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

        /// <summary>
        /// Gets or sets the unique password hash for the user. This password hash is typically used as the password  in the database.
        /// </summary>
        /// <value>The unique email of the user.</value>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the unique password salt for the user. This password salt is typically used as the password in the database.
        /// </summary>
        /// <value>The unique email of the user.</value>
        public byte[] PasswordSalt { get; set; }
    }
}
