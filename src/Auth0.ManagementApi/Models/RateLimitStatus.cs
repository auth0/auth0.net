using Auth0.Core.Exceptions;

namespace Auth0.ManagementApi.Models
{
    public class RateLimitStatus
    {
        public RateLimit RateLimit { get; set; }
        public string Source { get; set; }
    }
}