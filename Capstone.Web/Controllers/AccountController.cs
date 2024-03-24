// <copyright file="AccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TodoList.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.WebApi.Services;
    using TodoList.WebApi.Models.Models;

    public class AccountController : Controller
    {
        private readonly AuthenticationService authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (this.ModelState.IsValid)
            {
                string token = await this.authenticationService.GetTokenAsync(model.Email, model.Password);
                if (token != null)
                {
                    this.HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                    });

                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }

            return this.View(model);
        }
    }
}
