using System;
using System.Runtime.Serialization;

namespace Auth0.AuthenticationApi.Tokens
{
    /// <summary>
    /// Exception used to convey ways in which an identity token has failed to be validated.
    /// </summary>
    [Serializable]
    public class IdTokenValidationException : Exception
    {
        /// Create a new <see cref="IdTokenValidationException"/> with no error message.
        public IdTokenValidationException()
        {
        }

        /// <summary>
        /// Create a new <see cref="IdTokenValidationException"/> with a given error message.
        /// </summary>
        /// <param name="message">Message that describes how the token fails to meet validation requirements.</param>
        public IdTokenValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create a new <see cref="IdTokenValidationException"/> that contains a further inner 
        /// <see cref="Exception"/> describing how this token could not be validated.
        /// </summary>
        /// <param name="message">Message that describes how the token fails to meet validation requirements.</param>
        /// <param name="innerException">Inner exception that caused this validation exception.</param>
        public IdTokenValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected IdTokenValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}