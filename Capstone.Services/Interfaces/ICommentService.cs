// <copyright file="IComment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Models;
    using TodoList.Services.Models.Task;

    public interface ICommentService
    {
        Task AddCommentAsync(Comment content);
    }
}
