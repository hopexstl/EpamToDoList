// <copyright file="EntityNotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Exceptions;

/// <summary>
/// Represents errors that occur when a specified entity cannot be found in the data source.
/// </summary>
/// <remarks>
/// This exception should be thrown in situations where an operation attempts to retrieve an entity that does not exist,
/// such as looking up a record by a key that is not present in the database.
/// </remarks>
public class EntityNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor initializes a new instance of the <see cref="EntityNotFoundException"/> with no error message.
    /// </remarks>
    public EntityNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <remarks>
    /// This constructor initializes a new instance of the <see cref="EntityNotFoundException"/> class and sets the <see cref="Exception.Message"/> property to the provided error message.
    /// </remarks>
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}
