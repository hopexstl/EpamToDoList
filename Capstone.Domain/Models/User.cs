// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.WebApi.Models.Models
{
    /// <summary>
    /// Represents a user within the application. This class can be expanded to include additional user-related properties such as name, email, etc.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user. This identifier is typically used as the primary key in the database.
        /// </summary>
        /// <value>The unique identifier of the user.</value>
        public int Id { get; set; }
    }
}
