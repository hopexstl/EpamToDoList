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
    using System.Threading.Tasks;

    /// <summary>
    /// Provides services for interacting with the TodoList API to manage Todo items.
    /// </summary>
    public class TodoListWebApiService
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListWebApiService"/> class with a specified HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance used for HTTP requests.</param>
        public TodoListWebApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<TodoList>> GetAllTodoListsAsync()
        {
            var response = await httpClient.GetAsync($"{_baseUrl}/todolists");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var todoLists = JsonConvert.DeserializeObject<List<TodoList>>(content);

            return todoLists;
        }
    }
}
