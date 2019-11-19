using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /custom-domains endpoints.
    /// </summary>
    public class CustomDomainsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="CustomDomainsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="ILegacyApiConnection" /> which is used to communicate with the API.</param>
        internal CustomDomainsClient(ILegacyApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new custom domain and returns it.
        /// </summary>
        /// <param name="request">A <see cref="CustomDomainCreateRequest"/> representing the new domain.</param>
        /// <returns>The <see cref="CustomDomain"/> containing the newly created custom domain.</returns>
        /// <remarks>The custom domain will need to be verified before it starts accepting requests.</remarks>
        public Task<CustomDomain> CreateAsync(CustomDomainCreateRequest request)
        {
            return Connection.PostAsync<CustomDomain>("custom-domains", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a custom domain by its ID.
        /// </summary>
        /// <param name="id">The ID of the domain to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asyncronous delete operation.</returns>
        /// <remarks>When deleted, Auth0 will stop serving requests for this domain.</remarks>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("custom-domains/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <summary>
        /// Retrieves the status of every custom domain.
        /// </summary>
        /// <returns>A <see cref="IList{CustomDomain}"/> containing the details of every custom domain.
        public Task<IList<CustomDomain>> GetAllAsync()
        {
            return Connection.GetAsync<IList<CustomDomain>>("custom-domains", null, null, null, null);
        }

        /// <summary>
        /// Retrieves a custom domain status by its ID
        /// </summary>
        /// <param name="id">The ID of the domain to retrieve.</param>
        /// <returns>The <see cref="CustomDomain"/> that was requested.</returns>
        public Task<CustomDomain> GetAsync(string id)
        {
            return Connection.GetAsync<CustomDomain>("custom-domains/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <summary>
        /// Run the verification process for the custom domain. 
        /// </summary>
        /// <param name="id">The ID of the domain to verify.</param>
        /// <returns>The <see cref="CustomDomainVerification"/> that was requested.</returns>
        public Task<CustomDomainVerificationResponse> VerifyAsync(string id)
        {
            return Connection.PostAsync<CustomDomainVerificationResponse>("custom-domains/{id}/verify", null, null, null, 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null);
        }
    }
}