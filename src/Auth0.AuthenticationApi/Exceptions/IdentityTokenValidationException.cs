using System;

namespace Auth0.AuthenticationApi.Exceptions
{
    [Serializable]
    public class IdentityTokenValidationException : Exception
    {
        public IdentityTokenValidationException()
        {
        }

        public IdentityTokenValidationException(string message)
            : base(message)
        {
        }

        public IdentityTokenValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}