using System;
using System.Runtime.Serialization;

namespace Auth0.AuthenticationApi.Tokens
{
    /// <summary>
    /// Exception used to convey a token's key could not be found.
    /// </summary>
    [Serializable]
    public class IdTokenValidationKeyMissingException : IdTokenValidationException
    {
        /// Create a new <see cref="IdTokenValidationKeyMissingException"/> with no error message.
        public IdTokenValidationKeyMissingException()
        {
        }

        /// <summary>
        /// Create a new <see cref="IdTokenValidationKeyMissingException"/> with a given error message.
        /// </summary>
        /// <param name="message">Message that describes how the token's key could not be found.</param>
        public IdTokenValidationKeyMissingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create a new <see cref="IdTokenValidationKeyMissingException"/> that contains a further inner 
        /// <see cref="Exception"/> describing how this token's key could not be found.
        /// </summary>
        /// <param name="message">Message that describes how the token fails to meet validation requirements.</param>
        /// <param name="innerException">Inner exception that caused this validation exception.</param>
        public IdTokenValidationKeyMissingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected IdTokenValidationKeyMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}