using System;
using System.Runtime.Serialization;

namespace Auth0.AuthenticationApi.Exceptions
{
    public class IdentityTokenValidationException: Exception
    {
        public IdentityTokenValidationException(string message) : base(message)
        {
        }
    }
}