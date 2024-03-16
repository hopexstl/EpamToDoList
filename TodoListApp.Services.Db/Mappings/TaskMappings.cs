// <copyright file="TaskMappings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Db.Entity;
    using TodoList.Services.Models.Task;

    public static class TaskMappings
    {
        public static TaskEntity ToEntity(this TaskForCreate task)
        {
            return new TaskEntity(task.Title, task.Description, task.DueDate, task.Status, task.CreatedBy, task.Assignee, task.TodoListId);
        }
    }
}
