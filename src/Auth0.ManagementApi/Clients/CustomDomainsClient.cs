using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /custom-domains endpoints.
    /// </summary>
    public class CustomDomainsClient : BaseClient, ICustomDomainsClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CustomDomainsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public CustomDomainsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new custom domain and returns it.
        /// </summary>
        /// <param name="request">A <see cref="CustomDomainCreateRequest"/> representing the new domain.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="CustomDomain"/> containing the newly created custom domain.</returns>
        /// <remarks>The custom domain will need to be verified before it starts accepting requests.</remarks>
        public Task<CustomDomain> CreateAsync(CustomDomainCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<CustomDomain>(HttpMethod.Post, BuildUri("custom-domains"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a custom domain by its ID.
        /// </summary>
        /// <param name="id">The ID of the domain to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asyncronous delete operation.</returns>
        /// <remarks>When deleted, Auth0 will stop serving requests for this domain.</remarks>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"custom-domains/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves the status of every custom domain.
        /// </summary>
        /// <returns>A <see cref="IList{CustomDomain}"/> containing the details of every custom domain.</returns>
        public Task<IList<CustomDomain>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<CustomDomain>>(BuildUri("custom-domains"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a custom domain status by its ID
        /// </summary>
        /// <param name="id">The ID of the domain to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="CustomDomain"/> that was requested.</returns>
        public Task<CustomDomain> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<CustomDomain>(BuildUri($"custom-domains/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Run the verification process for the custom domain.
        /// </summary>
        /// <param name="id">The ID of the domain to verify.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="CustomDomainVerification"/> that was requested.</returns>
        public Task<CustomDomainVerificationResponse> VerifyAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<CustomDomainVerificationResponse>(HttpMethod.Post, BuildUri($"custom-domains/{EncodePath(id)}/verify"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
