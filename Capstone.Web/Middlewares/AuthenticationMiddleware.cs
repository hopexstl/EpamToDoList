namespace TodoList.WebApp.Middlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate next;
    private readonly HttpClient httpClient;

    public AuthenticationMiddleware(RequestDelegate next, HttpClient httpClient)
    {
        this.next = next;
        this.httpClient = httpClient;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Equals("/account/login", StringComparison.OrdinalIgnoreCase))
        {
            await this.next(context);
            return;
        }

        if (context.Request.Cookies.TryGetValue("token", out string token))
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44390/api/user/check-token");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            using (var response = await this.httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    await this.next(context);
                    return;
                }
            }
        }

        context.Response.Redirect("/account/login");
        return;
    }
}