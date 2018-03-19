namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to get a new token,
    /// based on a previously issued refresh token.
    /// </summary>
    public class RefreshTokenRequest
    {
        public string Audience { get; set; }

        /// <summary>
        /// A valid refresh token previously issued to the client.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets an optional scope for the access request.
        /// </summary>
        /// <remarks>
        /// The requested scope must not include any scope not originally granted
        /// by the resource owner, and if omitted is trated as equal to the scope originally
        /// granted by the resource owner.
        /// </remarks>
        public string Scope { get; set; }

        /// <summary>
        /// The client id for which the refresh token was issued.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The secret of the client for which the refresh token was issued.
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
