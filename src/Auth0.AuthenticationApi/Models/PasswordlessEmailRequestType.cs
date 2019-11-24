namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Type of passwordless email request.
    /// </summary>
    public enum PasswordlessEmailRequestType
    {
        /// <summary>
        /// Send a link.
        /// </summary>
        Link,

        /// <summary>
        /// Send a code.
        /// </summary>
        Code
    }
}