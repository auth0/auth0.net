namespace Auth0.ManagementApi.Models.RefreshTokens
{
    /// <summary>
    /// Represents the information required to Get <see cref="RefreshTokenInformation"/>
    /// </summary>
    public class RefreshTokenGetRequest
    {
        /// <summary>
        /// ID of the refresh token to retrieve
        /// </summary>
        public string Id { get; set; }
    }
}