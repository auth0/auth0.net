using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.NetworkAcl;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods for managing Network Access Control Lists (ACLs) in Auth0.
/// </summary>
public class NetworkAclClient : BaseClient, INetworkAclClient
{
    /// <summary>
    /// Creates a new instance of the <see cref="NetworkAclClient"/> class.
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="baseUri"></param>
    /// <param name="defaultHeaders"></param>
    public NetworkAclClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) 
        : base(connection, baseUri, defaultHeaders)
    {
    }

    /// <inheritdoc cref="INetworkAclClient.GetAllAsync"/>>
    public Task<IPagedList<NetworkAclEntry>> GetAllAsync(PaginationInfo? pagination = null, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
    /// <inheritdoc cref="INetworkAclClient.CreateAsync"/>>
    public Task CreateAsync(NetworkAclCreateRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc cref="INetworkAclClient.GetAsync"/>>
    public Task<NetworkAclEntry> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc cref="INetworkAclClient.DeleteAsync"/>>
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc cref="INetworkAclClient.UpdateAsync(string, NetworkAclPatchUpdateRequest, CancellationToken)"/>
    public Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPatchUpdateRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc cref="INetworkAclClient.UpdateAsync(string, NetworkAclPutUpdateRequest, CancellationToken)"/>
    public Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPutUpdateRequest request, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}