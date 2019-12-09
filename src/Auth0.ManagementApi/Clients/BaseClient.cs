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
        /// <param name="defaultHeaders"><see cref="IDictionary{string, string}"/> containing default headers included with every request this client makes.</param>
        protected BaseClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
        {
            Connection = connection;
            BaseUri = baseUri;
            DefaultHeaders = defaultHeaders;
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
    }
}
