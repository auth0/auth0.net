using System;

namespace Auth0.ManagementApi.Models
{
    /// <inheritdoc />
    public delegate void RateLimitEventHandler(object sender, RateLimitEventArgs e);

    /// <inheritdoc />
    public class RateLimitEventArgs : EventArgs
    {
        public RateLimitStatus RateLimitStatus;
    }
}