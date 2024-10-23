using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.RefreshTokens;

namespace Auth0.ManagementApi.Clients
{
    
    /// <inheritdoc cref="Auth0.ManagementApi.Clients.IRefreshTokenClient"/>
    public class RefreshTokenClient : BaseClient, IRefreshTokenClient
    {
        private const string RefreshTokensBasePath = "refresh-tokens";
        
        /// <summary>
        /// Initializes a new instance on <see cref="RefreshTokenClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public RefreshTokenClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) 
            : base(connection, baseUri, defaultHeaders)
        {
        }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Clients.IRefreshTokenClient.GetAsync"/>
        public Task<RefreshTokenInformation> GetAsync(RefreshTokenGetRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            if(string.IsNullOrEmpty(request.Id))
                throw new ArgumentException("Value cannot be null or empty.", nameof(request.Id));
            
            return Connection.GetAsync<RefreshTokenInformation>(
                BuildUri($"{RefreshTokensBasePath}/{EncodePath(request.Id)}"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Clients.IRefreshTokenClient.DeleteAsync"/>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"{RefreshTokensBasePath}/{EncodePath(id)}"),
                null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}