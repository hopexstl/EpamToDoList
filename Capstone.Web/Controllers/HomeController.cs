// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using Capstone.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using TodoList.Services.WebApi.Services;

    /// <summary>
    /// Controller responsible for handling requests for the home page and related actions within the application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly TodoListWebApiService todoListService;
        private readonly ILogger<HomeController> logger;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly string token;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public HomeController(ILogger<HomeController> logger, TodoListWebApiService todoListService, IHttpContextAccessor contextAccessor)
        {
            this.logger = logger;
            this.todoListService = todoListService;
            this.contextAccessor = contextAccessor;
            this.token = this.contextAccessor.HttpContext.Request.Cookies["token"];
        }

        public async Task<IActionResult> Index()
        {
            var todoLists = await this.todoListService.GetTodoListsAsync(this.token);
            return this.View(todoLists);
        }

        /// <summary>
        /// Serves the privacy policy view of the application.
        /// </summary>
        /// <returns>The privacy view.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Serves the error view in case of an application error. This action is decorated with <see cref="ResponseCacheAttribute"/>
        /// to prevent caching of the error view.
        /// </summary>
        /// <returns>The error view populated with error details.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
