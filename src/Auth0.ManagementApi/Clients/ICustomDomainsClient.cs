using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /custom-domains endpoints.
    /// </summary>
    public interface ICustomDomainsClient
    {
        /// <summary>
        /// Creates a new custom domain and returns it.
        /// </summary>
        /// <param name="request">A <see cref="CustomDomainCreateRequest"/> representing the new domain.</param>
        /// <returns>The new domain.</returns>
        /// <remarks>The custom domain will need to be verified before it starts accepting requests.</remarks>
        Task<CustomDomain> CreateAsync(CustomDomainCreateRequest request);

        /// <summary>
        /// Deletes a custom domain by its ID.
        /// </summary>
        /// <param name="id">The ID of the domain to delete.</param>
        /// <returns></returns>
        /// <remarks>When deleted, Auth0 will stop serving requests for this domain.</remarks>
        Task DeleteAsync(string id);

        /// <summary>
        /// Retrieves a custom domain status by its ID
        /// </summary>
        /// <param name="id">The ID of the domain to retrieve.</param>
        /// <returns>The domain.</returns>
        Task<CustomDomain> GetAsync(string id);

        /// <summary>
        /// Retrieves the status of every custom domain.
        /// </summary>
        /// <returns>The list of custom domains</returns>
        Task<IList<CustomDomain>> GetAllAsync();

        /// <summary>
        /// Run the verification process for the custom domain. 
        /// </summary>
        /// <param name="id">The ID of the domain to verify.</param>
        /// <returns></returns>
        Task<CustomDomainVerificationResponse> VerifyAsync(string id);
    }
}