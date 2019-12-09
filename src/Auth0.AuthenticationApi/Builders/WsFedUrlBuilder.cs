using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Builder class used to fluently construct a WS-Federation authorization URL.
    /// </summary>
    public class WsFedUrlBuilder : UrlBuilderBase<WsFedUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WsFedUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="String"/>.</param>
        /// <param name="clientId">Optional Client ID of the application.</param>
        public WsFedUrlBuilder(string baseUrl, string clientId = null)
            : base(baseUrl, "wsfed/{client}")
        {
            AddUrlSegment("client", clientId);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WsFedUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="Uri"/>.</param>
        /// <param name="clientId">Optional Client ID of the application.</param>
        public WsFedUrlBuilder(Uri baseUrl, string clientId = null)
            : base(baseUrl, "wsfed/{client}")
        {
            AddUrlSegment("client", clientId);
        }

        /// <summary>
        /// Adds the `client` URL segment specifying the Client ID of the application.
        /// </summary>
        /// <param name="clientId">Client ID of the application.</param>
        /// <returns>Current <see cref="WsFedUrlBuilder"/> to allow fluent configuration.</returns>
        public WsFedUrlBuilder WithClient(string clientId)
        {
            AddUrlSegment("client", clientId);
            return this;
        }

        /// <summary>
        /// Adds the `whr` query string parameter.
        /// </summary>
        /// <param name="value">Value of the `whr` parameter.</param>
        /// <returns>Current <see cref="WsFedUrlBuilder"/> to allow fluent configuration.</returns>
        public WsFedUrlBuilder WithWhr(string value)
        {
            return WithValue("whr", value);
        }

        /// <summary>
        /// Adds the `wctx` query string parameter.
        /// </summary>
        /// <param name="value">Value of the `wctx` parameter in key-value pair format, e.g. <code>xcrf=abc&amp;ru=/foo</code>.</param>
        /// <returns>Current <see cref="WsFedUrlBuilder"/> to allow fluent configuration.</returns>
        public WsFedUrlBuilder WithWctx(string value)
        {
            return WithValue("wctx", value);
        }

        /// <summary>
        /// Adds the `wctx` query string parameter.
        /// </summary>
        /// <param name="values">Dictionary containing the key-value pairs of the `wctx` parameter.</param>
        /// <returns>Current <see cref="WsFedUrlBuilder"/> to allow fluent configuration.</returns>
        public WsFedUrlBuilder WithWctx(IDictionary<string, string> values)
        {
            return WithWctx(String.Join("&", values.Select(kvp => $"{kvp.Key}={kvp.Value}")));
        }

        /// <summary>
        /// Adds the `wtrealm` query string parameter.
        /// </summary>
        /// <param name="value">Value of the `wtrealm` query string parameter.</param>
        /// <returns>Current <see cref="WsFedUrlBuilder"/> to allow fluent configuration.</returns>
        public WsFedUrlBuilder WithWtrealm(string value)
        {
            return WithValue("wtrealm", value);
        }
    }
}