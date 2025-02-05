using Auth0.ManagementApi.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /branding endpoints.
    /// </summary>
    public class BrandingClient : BaseClient, IBrandingClient
    {
        private readonly JsonConverter[] _brandingPhoneProviderConverters = 
            { new ListConverter<BrandingPhoneProvider>("providers") };
        
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
                {"disabled", request.Disabled?.ToString().ToLower()},
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
            return Connection.GetAsync<BrandingPhoneProvider>(
                BuildUri($"branding/phone/providers/{EncodePath(id)}"),
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task DeletePhoneProviderAsync(string id, CancellationToken cancellationToken = default)
        {
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
            return Connection.SendAsync<BrandingPhoneProvider>(
                new HttpMethod("PATCH"),
                BuildUri($"branding/phone/providers/{EncodePath(id)}"),
                request, 
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }
    }
}