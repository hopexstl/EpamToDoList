// <copyright file="AccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TodoList.Services.WebApi.Services;
    using TodoList.WebApi.Models.Models;

    public class AccountController : Controller
    {
        private readonly AuthenticationService authenticationService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountController(AuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            this.authenticationService = authenticationService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (this.ModelState.IsValid)
            {
                string token = await this.authenticationService.GetTokenAsync(model.Email, model.Password);
                if (token != null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, // Set to true only if the request is over HTTPS
                        SameSite = SameSiteMode.None,
                    };

                    // Append the cookie to the response
                    this.httpContextAccessor.HttpContext.Response.Cookies.Append("token", token, cookieOptions);

                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.httpContextAccessor.HttpContext.Response.Cookies.Delete("token");

            return this.RedirectToAction("Account", "Login");
        }
    }
}
