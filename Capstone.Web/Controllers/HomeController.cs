// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Web.Controllers
{
    using System.Diagnostics;
    using Capstone.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller responsible for handling requests for the home page and related actions within the application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Serves the main index view of the application.
        /// </summary>
        /// <returns>The index view.</returns>
        public IActionResult Index()
        {
            return this.View();
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
