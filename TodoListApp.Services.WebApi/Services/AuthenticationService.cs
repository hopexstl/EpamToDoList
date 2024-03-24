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
        public async Task<string> GetTokenAsync(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var loginData = new Dictionary<string, string>
            {
                { "Email", email },
                { "password", password },
            };

                var response = await client.PostAsync("https://localhost:44390/api/User/Login", new FormUrlEncodedContent(loginData));

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<TokenResponse>(responseData).AccessToken;
                    return token;
                }

                return null;
            }
        }
    }
}
