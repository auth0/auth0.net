using Auth0.AuthenticationApi.Models;
using System;

namespace Auth0.ManagementApi
{
    public class TokenStorageItem
    {
        public AccessTokenResponse AccessTokenResponse { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}