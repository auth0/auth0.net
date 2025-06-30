using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.NetworkAcl;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods for managing Network Access Control Lists (ACLs) in Auth0.
/// </summary>
public interface INetworkAclClient
{
  /// <summary>
  /// Get all access control list entries for your client.
  /// </summary>
  /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  /// <returns>An <see cref="IPagedList{NetworkAclEntry}"/> containing the Access Control List.</returns>
  Task<IPagedList<NetworkAclEntry>> GetAllAsync(PaginationInfo? pagination = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new access control list for your client.
  /// </summary>
  /// <param name="request"><see cref="NetworkAclCreateRequest"/> class containing all information required to create the ACL entry</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  Task CreateAsync(NetworkAclCreateRequest request, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a specific access control list entry for your client.
  /// </summary>
  /// <param name="id">The id of the access control list to retrieve.</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  /// <returns>An <see cref="NetworkAclEntry"/> containing the Access Control List.</returns>
  Task<NetworkAclEntry> GetAsync(string id, CancellationToken cancellationToken = default);
  
  /// <summary>
  /// Delete existing access control list for your client.
  /// </summary>
  /// <param name="id">The id of the ACL to delete.</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  Task DeleteAsync(string id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update existing access control list for your client.
  /// </summary>
  /// <param name="id">The id of the ACL to update.</param>
  /// <param name="request"><see cref="NetworkAclPatchUpdateRequest"/> containing information to update</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPatchUpdateRequest request , CancellationToken cancellationToken = default);
  
  /// <summary>
  /// Update existing access control list for your client.
  /// </summary>
  /// <param name="id">The id of the ACL to update.</param>
  /// <param name="request"><see cref="NetworkAclPutUpdateRequest"/> containing information to update</param>
  /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
  Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPutUpdateRequest request , CancellationToken cancellationToken = default);
}