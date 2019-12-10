using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Builder class used to fluently construct a SAML authorization URL.
    /// </summary>
    /// <remarks>
    /// See https://auth0.com/docs/api/authentication#accept-request for more details.
    /// </remarks>
    public class SamlUrlBuilder : UrlBuilderBase<SamlUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SamlUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="String"/>.</param>
        /// <param name="clientId">Client ID of the application.</param>
        public SamlUrlBuilder(string baseUrl, string clientId)
            : base(baseUrl, "samlp/{clientId}")
        {
            AddUrlSegment("clientId", clientId);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SamlUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="Uri"/>.</param>
        /// <param name="clientId">Client ID of the application.</param>
        public SamlUrlBuilder(Uri baseUrl, string clientId)
            : base(baseUrl, "samlp/{clientId}")
        {
            AddUrlSegment("clientId", clientId);
        }

        /// <summary>
        /// Adds the `connection` query string parameter specifying the connection name.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>Current <see cref="SamlUrlBuilder"/> to allow fluent configuration.</returns>
        public SamlUrlBuilder WithConnection(string connectionName)
        {
            return WithValue("connection", connectionName);
        }

        /// <summary>
        /// Adds the `RelayState` query string parameter.
        /// </summary>
        /// <param name="value">Value of `RelayState` parameter in key-value format, e.g. <code>xcrf=abc&amp;ru=/foo</code>.</param>
        /// <returns>Current <see cref="SamlUrlBuilder"/> to allow fluent configuration.</returns>
        /// <remarks>
        /// See https://auth0.com/docs/protocols/saml/saml-configuration/special-configuration-scenarios/idp-initiated-sso#auth0-as-identity-provider-where-idp-initiates-sso for more details on RelayState.
        /// </remarks>
        public SamlUrlBuilder WithRelayState(string value)
        {
            // This parameter must use PascalCase (i.e. RelayState) see https://github.com/auth0/auth0.net/issues/186 
            return WithValue("RelayState", value);
        }

        /// <summary>
        /// Adds the `RelayState` query string parameter.
        /// </summary>
        /// <param name="values">Dictionary containing key-value pairs for the `RelayState` parameter.</param>
        /// <returns>Current <see cref="SamlUrlBuilder"/> to allow fluent configuration.</returns>
        /// <remarks>
        /// See https://auth0.com/docs/protocols/saml/saml-configuration/special-configuration-scenarios/idp-initiated-sso#auth0-as-identity-provider-where-idp-initiates-sso for more details on RelayState.
        /// </remarks>
        public SamlUrlBuilder WithRelayState(IDictionary<string, string> values)
        {
            return WithRelayState(String.Join("&", values.Select(kvp => $"{kvp.Key}={kvp.Value}")));
        }
    }
}