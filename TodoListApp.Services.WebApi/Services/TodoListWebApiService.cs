// <copyright file="TodoListWebApiService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TodoListWebApiService
    {
        private readonly HttpClient httpClient;

        public TodoListWebApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
