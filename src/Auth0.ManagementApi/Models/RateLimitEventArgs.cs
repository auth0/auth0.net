using System;
using Auth0.Core.Exceptions;

namespace Auth0.ManagementApi.Models
{
    /// <inheritdoc />
    public delegate void RateLimitEventHandler(object sender, RateLimitEventArgs e);

    /// <inheritdoc />
    public class RateLimitEventArgs : EventArgs
    {
        public RateLimit RateLimit { get; set; }
        public string Source { get; set; }
    }
}