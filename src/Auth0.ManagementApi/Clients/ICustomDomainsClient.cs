namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface ICustomDomainsClient
  {
    /// <summary>
    /// Creates a new custom domain and returns it.
    /// </summary>
    /// <param name="request">A <see cref="CustomDomainCreateRequest"/> representing the new domain.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="CustomDomain"/> containing the newly created custom domain.</returns>
    /// <remarks>The custom domain will need to be verified before it starts accepting requests.</remarks>
    Task<CustomDomain> CreateAsync(CustomDomainCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a custom domain by its ID.
    /// </summary>
    /// <param name="id">The ID of the domain to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asyncronous delete operation.</returns>
    /// <remarks>When deleted, Auth0 will stop serving requests for this domain.</remarks>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the status of every custom domain.
    /// </summary>
    /// <returns>A <see cref="IList{CustomDomain}"/> containing the details of every custom domain.</returns>
    Task<IList<CustomDomain>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a custom domain status by its ID
    /// </summary>
    /// <param name="id">The ID of the domain to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="CustomDomain"/> that was requested.</returns>
    Task<CustomDomain> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Run the verification process for the custom domain. 
    /// </summary>
    /// <param name="id">The ID of the domain to verify.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="CustomDomainVerification"/> that was requested.</returns>
    Task<CustomDomainVerificationResponse> VerifyAsync(string id, CancellationToken cancellationToken = default);
  }
}
