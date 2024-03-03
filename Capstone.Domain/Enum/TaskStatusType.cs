// <copyright file="TaskStatusType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoListApp.WebApi.Models.Enum;

/// <summary>
/// Defines the possible states of a task within the Todo List application.
/// </summary>
public enum TaskStatusType
{
    /// <summary>
    /// Indicates that the task has not yet been started.
    /// </summary>
    NotStarted = 0,

    /// <summary>
    /// Indicates that the task is currently in progress.
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// Indicates that the task has been completed.
    /// </summary>
    Completed = 2,
}
