using System.Collections.Generic;
using JetBrains.Annotations;
using System.Linq;

namespace Auth0.AuthenticationApi.Client.Builders
{
    /// <summary>
    /// Used to build a WS Federation authorization URL.
    /// </summary>
    public class WsFedUrlBuilder : UrlBuilderBase<WsFedUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WsFedUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public WsFedUrlBuilder(string baseUrl) 
            : base(baseUrl, "wsfed/{client}")
        {
            AddUrlSegment("client", null); // Default to not using the client
        }

        /// <summary>
        /// Specifies the client ID for the URL.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <returns>WsFedUrlBuilder.</returns>
        public WsFedUrlBuilder WithClient(string clientId)
        {
            AddUrlSegment("client", clientId);

            return this;
        }

        /// <summary>
        /// Adds a qhr query string parameter.
        /// </summary>
        /// <param name="value">The value of the whr parameter.</param>
        /// <returns>WsFedUrlBuilder.</returns>
        public WsFedUrlBuilder WithWhr(string value)
        {
            AddQueryString("whr", value);

            return this;
        }

        /// <summary>
        /// Adds a wctx query string parameter.
        /// </summary>
        /// <param name="value">A string with the value of the wctx parameter. Must be in a name-value pair format, e.g. xcrf=abc&amp;ru=/foo</param>
        /// <returns>WsFedUrlBuilder.</returns>
        public WsFedUrlBuilder WithWctx(string value)
        {
            AddQueryString("wctx", value);

            return this;
        }

        /// <summary>
        /// Adds a wctx query string parameter.
        /// </summary>
        /// <param name="values">A dictionary containing the name-value pairs of the wctx parameter.</param>
        /// <returns>WsFedUrlBuilder.</returns>
        public WsFedUrlBuilder WithWctx(IDictionary<string, string> values)
        {
            AddQueryString("wctx", string.Join("&", values.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))));

            return this;
        }

        /// <summary>
        /// Adds a wtrealm query string parameter.
        /// </summary>
        /// <param name="value">The value of the wtrealm query string parameter.</param>
        /// <returns>WsFedUrlBuilder.</returns>
        public WsFedUrlBuilder WithWtrealm(string value)
        {
            AddQueryString("wtrealm", value);

            return this;
        }
    }
}