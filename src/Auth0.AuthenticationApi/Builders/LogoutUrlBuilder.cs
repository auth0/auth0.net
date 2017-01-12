namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Used to build a logout URL.
    /// </summary>
    public class LogoutUrlBuilder : UrlBuilderBase<LogoutUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public LogoutUrlBuilder(string baseUrl) 
            : base(baseUrl, "v2/logout")
        {
        }

        /// <summary>
        /// Adds a returnTo query string parameter.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The <see cref="LogoutUrlBuilder"/>.</returns>
        public LogoutUrlBuilder WithReturnUrl(string url)
        {
            AddQueryString("returnTo", url);

            return this;
        }

        /// <summary>
        /// Adds a client_id query string parameter.
        /// </summary>
        /// <param name="clientId">The URL.</param>
        /// <returns>The <see cref="LogoutUrlBuilder"/>.</returns>
        public LogoutUrlBuilder WithClientId(string clientId)
        {
            AddQueryString("client_id", clientId);

            return this;
        }

        /// <summary>
        /// Adds a federated query string parameter.
        /// </summary>
        /// <returns>The <see cref="LogoutUrlBuilder"/>.</returns>
        public LogoutUrlBuilder Federated()
        {
            AddQueryString("federated", null);

            return this;
        }


    }
}