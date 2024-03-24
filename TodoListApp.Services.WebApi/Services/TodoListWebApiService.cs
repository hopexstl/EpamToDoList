// <copyright file="TodoListWebApiService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.WebApi.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using TodoList.WebApi.Models.Models;

    public class TodoListWebApiService
    {
        private readonly HttpClient httpClient;
        private readonly string bearerToken;
        private readonly IConfiguration configuration;

        public TodoListWebApiService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.bearerToken = configuration["BearerToken"];
        }

        public async Task<List<TodoListModel>> GetTodoListsAsync(string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44390/api/Todolist");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await this.httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var todoLists = JsonSerializer.Deserialize<List<TodoListModel>>(
                        content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return todoLists;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching TodoLists.", ex);
            }
        }
    }
}
