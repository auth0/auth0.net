using System.Linq;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Used to build a SAML authorization URL.
    /// </summary>
    public class SamlUrlBuilder : UrlBuilderBase<SamlUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SamlUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="client">The client id.</param>
        public SamlUrlBuilder(string baseUrl, string client)
            :base(baseUrl, "samlp/{client}")
        {
            AddUrlSegment("client", client);
        }

        /// <summary>
        /// Adds a connection query string parameter.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>The <see cref="SamlUrlBuilder"/>.</returns>
        public SamlUrlBuilder WithConnection(string connectionName)
        {
            AddQueryString("connection", connectionName);

            return this;
        }

        /// <summary>
        /// Adds a relayState query string parameter.
        /// </summary>
        /// <param name="value">A string with the value of relayState parameter. Must be in a name-value pair format, e.g. xcrf=abc&amp;ru=/foo</param>
        /// <returns>The <see cref="SamlUrlBuilder"/>.</returns>
        public SamlUrlBuilder WithRelayState(string value)
        {
            // Note to future maintainers:
            // It is important to use correct casing! This parameter must use PascalCase (i.e. RelayState),
            // otherwise it will not be passed on correctly. See https://github.com/auth0/auth0.net/issues/186 
            AddQueryString("RelayState", value);

            return this;
        }

        /// <summary>
        /// Adds a relayState query string parameter.
        /// </summary>
        /// <param name="values">A dictionary containing the name-value pairs of the relayState parameter.</param>
        /// <returns>The <see cref="SamlUrlBuilder"/>.</returns>
        public SamlUrlBuilder WithRelayState(System.Collections.Generic.IDictionary<string, string> values)
        {
            // Note to future maintainers:
            // It is important to use correct casing! This parameter must use PascalCase (i.e. RelayState),
            // otherwise it will not be passed on correctly. See https://github.com/auth0/auth0.net/issues/186 
            AddQueryString("RelayState", string.Join("&", values.Select(kvp => $"{kvp.Key}={kvp.Value}")));

            return this;
        }

    }
}