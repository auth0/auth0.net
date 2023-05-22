namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IDeviceCredentialsClient
  {
    /// <summary>
    /// Gets a list of all the device credentials.
    /// </summary>
    /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
    /// <param name="includeFields">True if the fields specified are to be excluded from the result, false otherwise (defaults to true).</param>
    /// <param name="userId">The user id of the devices to retrieve.</param>
    /// <param name="clientId">The client id of the devices to retrieve.</param>
    /// <param name="type">The type of credentials.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
    Task<IList<DeviceCredential>> GetAllAsync(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of all the device credentials.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying device credentials.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
    Task<IPagedList<DeviceCredential>> GetAllAsync(GetDeviceCredentialsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new device credential.
    /// </summary>
    /// <param name="request">The request containing the details of the device credential to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="DeviceCredential"/>.</returns>
    Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a device credential.
    /// </summary>
    /// <param name="id">The id of the device credential to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
  }
}
