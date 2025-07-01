using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Sessions;

namespace Auth0.ManagementApi.Clients
{
    
    /// <inheritdoc cref="Auth0.ManagementApi.Clients.ISessionsClient"/>
    public class SessionsClient : BaseClient, ISessionsClient
    {
        private const string SessionsBasePath = "sessions";
        
        /// <summary>
        /// Initializes a new instance of <see cref="SessionsClient"/>.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="baseUri"></param>
        /// <param name="defaultHeaders"></param>
        public SessionsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) 
            : base(connection, baseUri, defaultHeaders)
        {
        }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Clients.ISessionsClient.GetAsync"/>
        public Task<Sessions> GetAsync(SessionsGetRequest request, CancellationToken cancellationToken = default)
        {
            request.ThrowIfNull();
            if(string.IsNullOrEmpty(request.Id))
                throw new ArgumentException("Value cannot be null or empty.", nameof(request.Id));
            
            return Connection.GetAsync<Sessions>(
                BuildUri($"{SessionsBasePath}/{EncodePath(request.Id)}"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc cref="Auth0.ManagementApi.Clients.ISessionsClient.DeleteAsync"/>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"{SessionsBasePath}/{EncodePath(id)}"),
                null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc cref="Auth0.ManagementApi.Clients.ISessionsClient.RevokeAsync"/>
        public Task RevokeAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Task>(HttpMethod.Post, 
                BuildUri($"{SessionsBasePath}/{EncodePath(id)}/revoke"),
                null,
                DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}