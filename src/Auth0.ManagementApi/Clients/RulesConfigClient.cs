using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /rules-configs endpoint
    /// </summary>
    public class RulesConfigClient : BaseClient, IRulesConfigClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RulesConfigClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public RulesConfigClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates or updates a rules config variable according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RulesConfigCreateOrUpdateRequest" /> containing the details of the rule to create or update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        public Task<RulesConfig> CreateOrUpdateAsync(RulesConfigCreateOrUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RulesConfig>(HttpMethod.Put, BuildUri($"rules-configs/{EncodePath(request.Key)}"), new { value = request.Value }, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a rules config variable.
        /// </summary>
        /// <param name="key">The key of the rules-config to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string key, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"rules-configs/{EncodePath(key)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

    }
}
