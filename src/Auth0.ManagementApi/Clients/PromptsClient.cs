using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Prompts;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /prompts endpoints.
    /// </summary>
    public class PromptsClient : BaseClient, IPromptsClient
    {
        private const string PromptsBasePath = "prompts";
        /// <summary>
        /// Initializes a new instance on <see cref="PromptsClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public PromptsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Get prompts settings
        /// </summary>
        /// <remarks>
        /// Get prompts settings
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Prompt"/> instance containing the information about the prompt settings.</returns>
        public Task<Prompt> GetAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Prompt>(BuildUri($"{PromptsBasePath}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update prompts settings.
        /// </summary>
        /// <remarks>
        /// Update prompts settings.
        /// </remarks>
        /// <param name="request">Specifies prompt setting values that are to be updated.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Prompt"/> that was updated.</returns>
        public Task<Prompt> UpdateAsync(PromptUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Prompt>(new HttpMethod("PATCH"), BuildUri($"{PromptsBasePath}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
