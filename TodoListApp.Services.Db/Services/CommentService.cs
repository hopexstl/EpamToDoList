// <copyright file="CommentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.Db.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TodoList.Services.Interfaces;
    using TodoList.Services.Models;
    using TodoListApp.Services.Db;

    public class CommentService : ICommentService
    {
        private readonly TodoListDbContext context;

        public CommentService(TodoListDbContext context)
        {
            context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            this.context.Comments.Add(comment);

            await this.context.SaveChangesAsync();
        }
    }
}
