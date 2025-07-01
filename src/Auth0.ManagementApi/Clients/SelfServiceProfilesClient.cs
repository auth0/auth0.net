using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Auth0.ManagementApi.Models.SelfServiceProfiles;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Client to manage Self Service Profiles.
/// </summary>
public class SelfServiceProfilesClient : BaseClient, ISelfServiceProfilesClient
{
    private readonly JsonConverter[] converters = [new PagedListConverter<SelfServiceProfile>("self_service_profiles")];
    public SelfServiceProfilesClient(
        IManagementConnection connection, 
        Uri baseUri, 
        IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
    {
    }

    /// <inheritdoc cref="ISelfServiceProfilesClient.GetAllAsync"/>
    public Task<IPagedList<SelfServiceProfile>> GetAllAsync(PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>();
            
        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<SelfServiceProfile>>(
            BuildUri("self-service-profiles", queryStrings),
            DefaultHeaders,
            converters,
            cancellationToken);
    }
        
    /// <inheritdoc cref="ISelfServiceProfilesClient.CreateAsync"/>
    public Task<SelfServiceProfile> CreateAsync(SelfServiceProfileCreateRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
            
        return Connection.SendAsync<SelfServiceProfile>(
            HttpMethod.Post,
            BuildUri("self-service-profiles"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="ISelfServiceProfilesClient.GetAsync"/>
    public Task<SelfServiceProfile> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.GetAsync<SelfServiceProfile>(
            BuildUri($"self-service-profiles/{EncodePath(id)}"),
            DefaultHeaders,
            null,
            cancellationToken);
    }
        
    /// <inheritdoc cref="ISelfServiceProfilesClient.DeleteAsync"/>
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Delete,
            BuildUri($"self-service-profiles/{EncodePath(id)}"),
            body: null,
            headers: DefaultHeaders,
            cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc cref="ISelfServiceProfilesClient.UpdateAsync"/>
    public Task<SelfServiceProfile> UpdateAsync(string id, SelfServiceProfileUpdateRequest request, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        return Connection.SendAsync<SelfServiceProfile>(
            new HttpMethod("PATCH"),
            BuildUri($"self-service-profiles/{EncodePath(id)}"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="ISelfServiceProfilesClient.CreateSsoTicketAsync"/>
    public Task<SelfServiceSsoTicket> CreateSsoTicketAsync(string id, SelfServiceSsoTicketCreateRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        id.ThrowIfNull();
        return Connection.SendAsync<SelfServiceSsoTicket>(
            HttpMethod.Post,
            BuildUri($"self-service-profiles/{EncodePath(id)}/sso-ticket"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);        
    }
        
    /// <inheritdoc cref="ISelfServiceProfilesClient.RevokeSsoTicketAsync"/>
    public Task RevokeSsoTicketAsync(string profileId, string ticketId, CancellationToken cancellationToken = default)
    {
        profileId.ThrowIfNull();
        ticketId.ThrowIfNull();
            
        return Connection.SendAsync<SelfServiceSsoTicket>(
            HttpMethod.Post,
            BuildUri($"self-service-profiles/{EncodePath(profileId)}/sso-ticket/{EncodePath(ticketId)}/revoke"),
            null,
            DefaultHeaders,
            cancellationToken: cancellationToken);   
    }
        
    /// <inheritdoc cref="ISelfServiceProfilesClient.GetCustomTextForSelfServiceProfileAsync"/>
    public Task<object> GetCustomTextForSelfServiceProfileAsync(string id, string language, string page,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        language.ThrowIfNull();
        page.ThrowIfNull();
        return Connection.GetAsync<object>(
            BuildUri($"self-service-profiles/{EncodePath(id)}/custom-text/{EncodePath(language)}/{EncodePath(page)}"),
            DefaultHeaders,
            null,
            cancellationToken);
    }

    /// <inheritdoc cref="ISelfServiceProfilesClient.SetCustomTextForSelfServiceProfileAsync"/>
    public Task<object> SetCustomTextForSelfServiceProfileAsync(string id, string language, string page, object body,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        language.ThrowIfNull();
        page.ThrowIfNull();
        return Connection
            .SendAsync<object>(
                HttpMethod.Put,
                BuildUri($"self-service-profiles/{EncodePath(id)}/custom-text/{EncodePath(language)}/{EncodePath(page)}"),
                body,
                DefaultHeaders,
                cancellationToken: cancellationToken);
    }
}