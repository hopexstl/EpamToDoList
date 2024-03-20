// <copyright file="TodoListWebApiService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using TodoList.WebApi.Models.Models;

    public class TodoListWebApiService
    {
        private readonly HttpClient httpClient;

        public TodoListWebApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<TodoListModel>> GetTodoListsAsync()
        {
            var response = await this.httpClient.GetAsync("TodoList");

            var content = await response.Content.ReadAsStringAsync();
            var todoLists = JsonSerializer.Deserialize<List<TodoListModel>>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return todoLists;
        }
    }
}
