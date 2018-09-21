using System;
using System.Net.Http;
using Auth0.AuthorizationApi.Clients;
using Auth0.Core.Http;

namespace Auth0.AuthorizationApi
{
    public class AuthorizationApiClient
    {
        private readonly ApiConnection _apiConnection;
      
        public IGroupsClient Groups { get; }
      
        public IRolesClient Roles { get; }
      
        public IPermissionsClient Permissions { get; }
      
        public IUsersClient Users { get; }
      
        /// <summary>Gets information about the last API call;</summary>
        public ApiInfo GetLastApiInfo()
        {
          return _apiConnection.ApiInfo;
        }
      
        private AuthorizationApiClient(ApiConnection apiConnection)
        {
          _apiConnection = apiConnection;
          Groups = new GroupsClient(_apiConnection);
          Roles = new RolesClient(_apiConnection);
          Permissions = new PermissionsClient(_apiConnection);
          Users = new UsersClient(_apiConnection);
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="T:System.Net.Http.HttpMessageHandler" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
          : this(new ApiConnection(token, baseUri.AbsoluteUri, diagnostics ?? DiagnosticsHeader.Default, handler))
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="httpClient">The <see cref="T:System.Net.Http.HttpClient" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics, HttpClient httpClient)
          : this(new ApiConnection(token, baseUri.AbsoluteUri, diagnostics ?? DiagnosticsHeader.Default, httpClient))
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public AuthorizationApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics)
          : this(token, baseUri, diagnostics, (HttpMessageHandler) null)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="handler">The <see cref="T:System.Net.Http.HttpMessageHandler" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, Uri baseUri, HttpMessageHandler handler)
          : this(token, baseUri, null, handler)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="httpClient">The <see cref="T:System.Net.Http.HttpClient" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, Uri baseUri, HttpClient httpClient)
          : this(token, baseUri, (DiagnosticsHeader) null, httpClient)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        public AuthorizationApiClient(string token, Uri baseUri)
          : this(token, baseUri, null, (HttpMessageHandler) null)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="T:System.Net.Http.HttpMessageHandler" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, string domain, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
          : this(token, new Uri("https://" + domain + "/api/v2"), diagnostics, handler)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="httpClient">The <see cref="T:System.Net.Http.HttpClient" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, string domain, DiagnosticsHeader diagnostics, HttpClient httpClient)
          : this(token, new Uri("https://" + domain + "/api/v2"), diagnostics, httpClient)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public AuthorizationApiClient(string token, string domain, DiagnosticsHeader diagnostics)
          : this(token, new Uri("https://" + domain + "/api/v2"), diagnostics, (HttpMessageHandler) null)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="handler">The <see cref="T:System.Net.Http.HttpMessageHandler" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, string domain, HttpMessageHandler handler)
          : this(token, new Uri("https://" + domain + "/api/v2"), (DiagnosticsHeader) null, handler)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="httpClient">The <see cref="T:System.Net.Http.HttpClient" /> which is used for HTTP requests</param>
        public AuthorizationApiClient(string token, string domain, HttpClient httpClient)
          : this(token, new Uri("https://" + domain + "/api/v2"), (DiagnosticsHeader) null, httpClient)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Auth0.AuthorizationApi.AuthorizationApiClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        public AuthorizationApiClient(string token, string domain)
          : this(token, new Uri("https://" + domain + "/api/v2"), null, (HttpMessageHandler) null)
        {
        }
    }
}