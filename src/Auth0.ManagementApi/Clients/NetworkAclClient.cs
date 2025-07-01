using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Auth0.ManagementApi.Models.NetworkAcl;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods for managing Network Access Control Lists (ACLs) in Auth0.
/// </summary>
public class NetworkAclClient : BaseClient, INetworkAclClient
{
    private readonly JsonConverter[] _converters = [new PagedListConverter<NetworkAclEntry>("network_acls")];
    
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
        var queryStrings = new Dictionary<string, string>();
        
        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<NetworkAclEntry>>(
            BuildUri("network-acls", queryStrings),
            DefaultHeaders,
            _converters,
            cancellationToken);
    }
    
    /// <inheritdoc cref="INetworkAclClient.CreateAsync"/>>
    public Task CreateAsync(NetworkAclCreateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Post,
            BuildUri("network-acls"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="INetworkAclClient.GetAsync"/>>
    public Task<NetworkAclEntry> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        
        return Connection.GetAsync<NetworkAclEntry>(
            BuildUri($"network-acls/{EncodePath(id)}"),
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="INetworkAclClient.DeleteAsync"/>>
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        
        return Connection.SendAsync<object>(
            HttpMethod.Delete, 
            BuildUri($"network-acls/{EncodePath(id)}"),
            null,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="INetworkAclClient.UpdateAsync(string, NetworkAclPatchUpdateRequest, CancellationToken)"/>
    public Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPatchUpdateRequest request, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        
        return Connection.SendAsync<NetworkAclEntry>(
            new HttpMethod("PATCH"),
            BuildUri($"network-acls/{EncodePath(id)}"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="INetworkAclClient.UpdateAsync(string, NetworkAclPutUpdateRequest, CancellationToken)"/>
    public Task<NetworkAclEntry> UpdateAsync(string id, NetworkAclPutUpdateRequest request, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        
        return Connection.SendAsync<NetworkAclEntry>(
            new HttpMethod("PUT"),
            BuildUri($"network-acls/{EncodePath(id)}"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }
}