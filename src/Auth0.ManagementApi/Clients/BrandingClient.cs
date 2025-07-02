using Auth0.ManagementApi.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods to access the /branding endpoints.
/// </summary>
public class BrandingClient : BaseClient, IBrandingClient
{
    private readonly JsonConverter[] _brandingPhoneProviderConverters =
        [new ListConverter<BrandingPhoneProvider>("providers")];
        
    private readonly JsonConverter[] _brandingPhoneNotificationTemplateConverters =
        [new ListConverter<BrandingPhoneNotificationTemplate>("templates")];
        
    /// <summary>
    /// Initializes a new instance of <see cref="BrandingClient"/>.
    /// </summary>
    /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
    /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
    /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
    public BrandingClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
        : base(connection, baseUri, defaultHeaders)
    {
    }

    /// <inheritdoc />
    public Task<Branding> GetAsync(CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<Branding>(BuildUri("branding"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<Branding> UpdateAsync(BrandingUpdateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<Branding>(new HttpMethod("PATCH"), BuildUri("branding"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<UniversalLoginTemplate> GetUniversalLoginTemplateAsync(CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<UniversalLoginTemplate>(BuildUri("branding/templates/universal-login"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteUniversalLoginTemplateAsync(CancellationToken cancellationToken = default)
    {
        return Connection
            .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri("branding/templates/universal-login"),
                null,
                DefaultHeaders,
                cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc />
    public Task<UniversalLoginTemplate> SetUniversalLoginTemplateAsync(UniversalLoginTemplateUpdateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<UniversalLoginTemplate>(HttpMethod.Put, BuildUri("branding/templates/universal-login"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<BrandingPhoneProvider>> GetAllPhoneProvidersAsync(
        BrandingPhoneProviderGetRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>
        {
            {"disabled", request?.Disabled?.ToString().ToLower()},
        };
        return Connection.GetAsync<IList<BrandingPhoneProvider>>(
            BuildUri("branding/phone/providers", queryStrings),
            DefaultHeaders,
            cancellationToken: cancellationToken,
            converters:_brandingPhoneProviderConverters);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneProvider> CreatePhoneProviderAsync(
        BrandingPhoneProviderCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<BrandingPhoneProvider>(
            HttpMethod.Post,
            BuildUri("branding/phone/providers"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneProvider> GetPhoneProviderAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.GetAsync<BrandingPhoneProvider>(
            BuildUri($"branding/phone/providers/{EncodePath(id)}"),
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeletePhoneProviderAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection
            .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"branding/phone/providers/{EncodePath(id)}"),
                null,
                DefaultHeaders,
                cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneProvider> UpdatePhoneProviderAsync(
        string id,
        BrandingPhoneProviderUpdateRequest request,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<BrandingPhoneProvider>(
            new HttpMethod("PATCH"),
            BuildUri($"branding/phone/providers/{EncodePath(id)}"),
            request, 
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneTestNotificationResponse> SendBrandingPhoneTestNotificationAsync(
        string id,
        BrandingPhoneTestNotificationRequest request,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<BrandingPhoneTestNotificationResponse>(
            HttpMethod.Post,
            BuildUri($"branding/phone/providers/{EncodePath(id)}/try"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<BrandingPhoneNotificationTemplate>> GetAllBrandingPhoneNotificationTemplatesAsync(
        BrandingPhoneNotificationTemplatesGetRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>
        {
            {"disabled", request?.Disabled?.ToString().ToLower()},
        };
            
        return Connection.GetAsync<IList<BrandingPhoneNotificationTemplate>>(
            BuildUri("branding/phone/templates", queryStrings),
            DefaultHeaders,
            cancellationToken: cancellationToken,
            converters:_brandingPhoneNotificationTemplateConverters);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneNotificationTemplate> CreateBrandingPhoneNotificationTemplateAsync(
        BrandingPhoneNotificationTemplateCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<BrandingPhoneNotificationTemplate>(
            HttpMethod.Post,
            BuildUri("branding/phone/templates"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneNotificationTemplate> GetBrandingPhoneNotificationTemplateAsync(
        string id,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.GetAsync<BrandingPhoneNotificationTemplate>(
            BuildUri($"branding/phone/templates/{EncodePath(id)}"),
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteBrandingPhoneNotificationTemplateAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection
            .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"branding/phone/templates/{EncodePath(id)}"),
                null,
                DefaultHeaders,
                cancellationToken: cancellationToken);       
    }

    /// <inheritdoc />
    public Task<BrandingPhoneNotificationTemplate> UpdateBrandingPhoneNotificationTemplate(
        string id,
        BrandingPhoneNotificationTemplateUpdateRequest request,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<BrandingPhoneNotificationTemplate>(
            new HttpMethod("PATCH"),
            BuildUri($"branding/phone/templates/{EncodePath(id)}"),
            request, 
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneNotificationTemplate> ResetBrandingPhoneNotificationTemplate(
        string id,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<BrandingPhoneNotificationTemplate>(
            new HttpMethod("PATCH"),
            BuildUri($"branding/phone/templates/{EncodePath(id)}/reset"),
            null, 
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingPhoneTestNotificationResponse> SendBrandingPhoneTemplateTestNotificationAsync(string id, BrandingPhoneTestNotificationRequest request,
        CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<BrandingPhoneTestNotificationResponse>(
            HttpMethod.Post,
            BuildUri($"branding/phone/templates/{EncodePath(id)}/try"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingTheme> CreateBrandingThemeAsync(
        BrandingThemeCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<BrandingTheme>(
            HttpMethod.Post,
            BuildUri($"branding/themes"),
            request,
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingTheme> GetDefaultBrandingThemeAsync(CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<BrandingTheme>(
            BuildUri($"branding/themes/default"),
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingTheme> GetBrandingThemeAsync(string brandingThemeId, CancellationToken cancellationToken = default)
    {
        brandingThemeId.ThrowIfNull();
            
        return Connection.GetAsync<BrandingTheme>(
            BuildUri($"branding/themes/{EncodePath(brandingThemeId)}"),
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteBrandingThemeAsync(string brandingThemeId, CancellationToken cancellationToken = default)
    {
        brandingThemeId.ThrowIfNull();
            
        return Connection
            .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"branding/themes/{EncodePath(brandingThemeId)}"),
                null,
                DefaultHeaders,
                cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<BrandingTheme> UpdateBrandingThemeAsync(string brandingThemeId, BrandingThemeUpdateRequest request, CancellationToken cancellationToken = default)
    {
        brandingThemeId.ThrowIfNull();
            
        return Connection.SendAsync<BrandingTheme>(
            new HttpMethod("PATCH"),
            BuildUri($"branding/themes/{EncodePath(brandingThemeId)}"),
            request, 
            DefaultHeaders,
            cancellationToken: cancellationToken);
    }
}