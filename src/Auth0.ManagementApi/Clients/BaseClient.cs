using Auth0.Core.Http;
using System;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Base class from which all Client classes inherit.
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// <see cref="IManagementConnection"/> used to make all API calls.
        /// </summary>
        protected IManagementConnection Connection { get; }

        /// <summary>
        /// <see cref="Uri"/> of the endpoint to use in making API calls.
        /// </summary>
        protected Uri BaseUri { get; }

        /// <summary>
        /// Default headers included with every request this client makes.
        /// </summary>
        protected IDictionary<string, string> DefaultHeaders { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        protected BaseClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
            DefaultHeaders = defaultHeaders ?? throw new ArgumentNullException(nameof(defaultHeaders));
        }

        /// <summary>
        /// Build the <see cref="Uri"/> for this API request given a <paramref name="resource"/> and
        /// <paramref name="queryStrings"/>.
        /// </summary>
        /// <param name="resource">Name of the resource to be appended to the path.</param>
        /// <param name="queryStrings">Query strings that should be combined with the URL.</param>
        /// <returns>Completed absolute URI for the request.</returns>
        protected Uri BuildUri(string resource, IDictionary<string, string> queryStrings = null)
        {
            return Utils.BuildUri(BaseUri.AbsoluteUri, resource, null, queryStrings);
        }

        /// <summary>
        /// Encode a value so it can be successfully used in the path.
        /// </summary>
        /// <param name="value">Value to encode for the path.</param>
        /// <returns>URI encoded/escaped value that can be used in the path.</returns>
        protected string EncodePath(string value)
        {
            return Uri.EscapeDataString(value);
        }
    }
}
