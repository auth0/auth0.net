using JetBrains.Annotations;

namespace Auth0.AuthenticationApi.Client.Builders
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
            : base(baseUrl, "logout")
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
    }
}