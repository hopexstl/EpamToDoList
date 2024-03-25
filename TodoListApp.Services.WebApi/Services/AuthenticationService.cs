// <copyright file="AuthenticationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.Services.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TodoList.WebApi.Models.Models;

    public class AuthenticationService
    {
        private readonly HttpClient httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var loginData = new Dictionary<string, string>
            {
                { "Email", email },
                { "password", password },
            };

                var jsonContent = JsonConvert.SerializeObject(loginData);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44390/api/User/Login");
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    return token;
                }

                return null;
            }
        }
    }
}
