namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// The type of Passwordless email request.
    /// </summary>
    public enum PasswordlessEmailRequestType
    {
        /// <summary>
        /// Sends a link.
        /// </summary>
        Link,

        /// <summary>
        /// Sends a code.
        /// </summary>
        Code
    }
}