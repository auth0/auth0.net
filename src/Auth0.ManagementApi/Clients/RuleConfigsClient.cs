using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /rules-configs endpoint
    /// </summary>
    public class RuleConfigsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RuleConfigsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public RuleConfigsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new rules-config according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        public Task<RulesConfig> CreateAsync(RuleConfigCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RulesConfig>(HttpMethod.Put, BuildUri($"rules-configs/{EncodePath(request.Key)}"), new { value = request.Value }, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a rules-config.
        /// </summary>
        /// <param name="id">The key of the rules-config to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string key, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"rules-configs/{EncodePath(key)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

    }
}
