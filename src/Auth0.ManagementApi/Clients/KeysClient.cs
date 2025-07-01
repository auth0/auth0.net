using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Keys;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using EncryptionKey = Auth0.ManagementApi.Models.Keys.EncryptionKey;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods to access the /keys endpoints.
/// </summary>
public class KeysClient : BaseClient, IKeysClient
{
    readonly JsonConverter[] converters = [new PagedListConverter<EncryptionKey>("keys")];
    /// <summary>
    /// Initializes a new instance of the <see cref="KeysClient"/> class.
    /// </summary>
    /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
    /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
    /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
    public KeysClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
        : base(connection, baseUri, defaultHeaders)
    {
    }

    /// <summary>
    /// Get all Application Signing Keys
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>All available signing keys <see cref="Key" />.</returns>
    public Task<IList<Key>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<IList<Key>>(BuildUri("keys/signing"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Get an Application Signing Key by its key ID.
    /// </summary>
    /// <param name="kid">The ID of the key to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Key"/> that was requested.</returns>
    public Task<Key> GetAsync(string kid, CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<Key>(BuildUri($"keys/signing/{EncodePath(kid)}"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Rotate the Application Signing Key.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The next rotated key's cert and kid.</returns>
    public Task<RotateSigningKeyResponse> RotateSigningKeyAsync( CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<RotateSigningKeyResponse>(HttpMethod.Post, BuildUri("keys/signing/rotate"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Revoke an Application Signing Key by its key ID.
    /// </summary>
    /// <param name="kid">The ID of the key to revoke.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The revoked key's cert and kid.</returns>
    public Task<RevokeSigningKeyResponse> RevokeSigningKeyAsync(string kid, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<RevokeSigningKeyResponse>(HttpMethod.Put, BuildUri($"keys/signing/{EncodePath(kid)}/revoke"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc cref="IKeysClient.GetAllEncryptionKeysAsync"/>
    public Task<IPagedList<EncryptionKey>> GetAllEncryptionKeysAsync(
        PaginationInfo pagination, CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>();

        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }
            
        return Connection.GetAsync<IPagedList<EncryptionKey>>(
            BuildUri("keys/encryption", queryStrings), DefaultHeaders, converters, cancellationToken);
    }

    /// <inheritdoc cref="IKeysClient.CreateEncryptionKeyAsync"/>
    public Task<EncryptionKey> CreateEncryptionKeyAsync(
        EncryptionKeyCreateRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.Type.ThrowIfNull();

        return Connection.SendAsync<EncryptionKey>(
            HttpMethod.Post,
            BuildUri("keys/encryption"),
            request, 
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IKeysClient.GetEncryptionKeyAsync"/>
    public Task<EncryptionKey> GetEncryptionKeyAsync(
        EncryptionKeyGetRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.Kid.ThrowIfNull();
            
        return Connection.GetAsync<EncryptionKey>(
            BuildUri($"keys/encryption/{EncodePath(request.Kid)}"), DefaultHeaders, null, cancellationToken);
    }
        
    /// <inheritdoc cref="IKeysClient.DeleteEncryptionKeyAsync"/>
    public Task DeleteEncryptionKeyAsync(string kid, CancellationToken cancellationToken = default)
    {
        kid.ThrowIfNull();
            
        return Connection.SendAsync<object>(
            HttpMethod.Delete,
            BuildUri($"keys/encryption/{EncodePath(kid)}"),
            null,
            DefaultHeaders, 
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IKeysClient.ImportEncryptionKeyAsync"/>
    public Task<EncryptionKey> ImportEncryptionKeyAsync(
        EncryptionKeyImportRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.Kid.ThrowIfNull();
            
        return Connection.SendAsync<EncryptionKey>(
            HttpMethod.Post,
            BuildUri($"keys/encryption/{EncodePath(request.Kid)}"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IKeysClient.CreatePublicWrappingKeyAsync"/>
    public Task<WrappingKey> CreatePublicWrappingKeyAsync(
        WrappingKeyCreateRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.Kid.ThrowIfNull();

        return Connection.SendAsync<WrappingKey>(
            HttpMethod.Post,
            BuildUri($"keys/encryption/{EncodePath(request.Kid)}/wrapping-key"),
            body: null,
            headers: DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IKeysClient.RekeyAsync"/>
    public Task RekeyAsync(CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Post,
            BuildUri("keys/encryption/rekey"),
            body: null,
            headers: DefaultHeaders,
            cancellationToken: cancellationToken);
    }
}