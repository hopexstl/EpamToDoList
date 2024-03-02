// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone.Web.Models
{
    /// <summary>
    /// Represents the model for error information to be displayed in views. This model includes details about the error such as a request ID.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the current HTTP request. This can be used to correlate the error with server logs.
        /// </summary>
        /// <value>The unique identifier of the HTTP request that resulted in an error.</value>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request ID should be shown in the error view. This is determined based on the presence of a non-empty request ID.
        /// </summary>
        /// <value><c>true</c> if the request ID is not null or empty; otherwise, <c>false</c>.</value>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
