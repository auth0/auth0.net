namespace Auth0
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides access to Auth0 services.
    /// </summary>
    public class Client
    {
        private static readonly Regex NextRelLinkRegex = new Regex("<(?<url>.*)>.*rel=\"next\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly string clientID;
        private readonly string clientSecret;
        private AccessToken currentToken;
        private readonly RestClient client;

        /// <summary>
        /// Creates an instance of the client.
        /// </summary>
        /// <param name="clientID">The client id of the application, as shown in the dashboard settings.</param>
        /// <param name="clientSecret">The client secret of the application, as shown in the dashboard settings.</param>
        /// <param name="domain">The domain for the Auth0 server.</param>
        /// <param name="webProxy">Proxy to use for requests made by this client instance. Passed on to underying WebRequest if set.</param>
        /// <param name="diagnostics">A <see cref="DiagnosticsHeader"/> instance that contains diagnostic information sent to Auth0.  Default = <see cref="DiagnosticsHeader.Default"/> </param>
        public Client(string clientID, string clientSecret, string domain, IWebProxy webProxy = null, DiagnosticsHeader diagnostics = null)
            : this(clientID, domain, webProxy, diagnostics)
        {
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException("clientSecret");
            }

            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// Creates an instance of the client for unauthenticated requests.
        /// </summary>
        /// <remarks>This constructor does not take a clientSecret, and thus only provides
        /// access to operations that don't require a clientSecret or access token.</remarks>
        /// <param name="clientID">The client id of the application, as shown in the dashboard settings.</param>
        /// <param name="domain">The domain for the Auth0 server.</param>
        /// <param name="webProxy">Proxy to use for requests made by this client instance. Passed on to underying WebRequest if set.</param>
        /// <param name="diagnostics">A <see cref="DiagnosticsHeader"/> instance that contains diagnostic information sent to Auth0.  Default = <see cref="DiagnosticsHeader.Default"/> </param>
        public Client(string clientID, string domain, IWebProxy webProxy = null, DiagnosticsHeader diagnostics = null)
        {
            if (string.IsNullOrEmpty(clientID))
            {
                throw new ArgumentNullException("clientID");
            }

            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException("domain");
            }

            this.clientID = clientID;

            Uri parsedDomain;
            if (Uri.TryCreate(domain, UriKind.Absolute, out parsedDomain) ||
                Uri.TryCreate("https://" + domain, UriKind.Absolute, out parsedDomain))
            {
                this.client = new RestClient(parsedDomain);
            }
            else
            {
                throw new ArgumentException("the domain URI could not be parsed", "domain");
            }

            if (webProxy != null)
            {
                this.client.Proxy = webProxy;
            }

            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }
            if (!Object.ReferenceEquals(diagnostics, DiagnosticsHeader.Suppress))
            {
                client.AddDefaultHeader("Auth0-Client", diagnostics.ToString());
            }
        }

        private string GetClientSecretOrThrow()
        {
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new InvalidOperationException("This operation requires a clientSecret, which was not provided. Use the constructor that receives the clientSecret as an argument.");
            }

            return this.clientSecret;
        }

        /// <summary>
        /// Returns a list of all the connections defined for the application.
        /// </summary>
        /// <returns>An IEnumerable of connections.</returns>
        public Page<Connection> GetConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(pageSize: pageSize);
        }

        /// <summary>
        /// Returns a list of all the social connections defined for the application.
        /// </summary>
        /// <returns>An IEnumerable of connections.</returns>
        public Page<Connection> GetSocialConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(onlySocials: true, pageSize: pageSize);
        }

        /// <summary>
        /// Returns a list of all the enterprise connections defined for the application.
        /// </summary>
        /// <returns>An IEnumerable of connections.</returns>
        public Page<Connection> GetEnterpriseConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(onlyEnterprise: true, pageSize: pageSize);
        }

        /// <summary>
        /// Creates a new connection using a provisioning ticket.
        /// </summary>
        /// <param name="provisioningTicket">The provisioning ticket containing the options for the new connection.</param>
        /// <returns>An instance of CreateConnectionResult containing the results of the operation.</returns>
        public CreateConnectionResult CreateConnection(ProvisioningTicket provisioningTicket)
        {
            var connectionTicket = new Connection(
                provisioningTicket.strategy,
                provisioningTicket.options["tenant_domain"]);

            var extraProperties = provisioningTicket.options.Keys.Except(
                new string[] { "tenant_domain" });

            extraProperties.ToList().ForEach(k =>
            {
                connectionTicket.Options.Add(k, provisioningTicket.options[k]);
            });

            try
            {
                var connection = this.CreateConnection(connectionTicket);
                return new CreateConnectionResult
                {
                    worked = true,
                    provisioning_ticket_url = connection.ProvisioningTicketUrl
                };
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new CreateConnectionResult
                {
                    worked = false,
                    error = ex.Message
                };
            }
        }

        /// <summary>
        /// Creates a new connection.
        /// </summary>
        /// <param name="ticket">An instance of a Connection object representing the connection to create.</param>
        /// <returns>An instance of the Connection object created.</returns>
        public Connection CreateConnection(Connection ticket)
        {
            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/connections?access_token=" + accessToken, Method.POST);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(ticket);

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }

            return JsonConvert.DeserializeObject<Connection>(result.Content);
        }

        /// <summary>
        /// Deletes a previously created connection.
        /// </summary>
        /// <param name="connectionName">The name of the connection to delete.</param>
        public void DeleteConnection(string connectionName)
        {
            var accessToken = this.GetAccessToken();
            var request = new RestRequest("/api/connections/{name}?access_token={accessToken}", Method.DELETE);

            request.AddParameter("name", connectionName, ParameterType.UrlSegment);
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            this.client.Execute(request);
        }

        /// <summary>
        /// Gets the first page of users available in a connection.
        ///
        /// </summary>
        /// <param name="connectionName">The connection name.</param>
        /// <returns>An Page and IEnumerable of User instances.</returns>
        public Page<User> GetUsersByConnection(string connectionName, int pageSize = 0)
        {
            return this.GetUsersByConnection(connectionName, string.Empty, pageSize);
        }

        /// <summary>
        /// Gets the first page of users available in a connection that match a search string.
        /// 
        /// If the connection doesn't have a directory or it is a social connection like 
        /// Google OAuth 2 it will return all the users that have logged in to your 
        /// application at least once.
        /// 
        /// If the connection is an enterprise connection and supports directory queries it will fetch
        /// the users from there.
        /// 
        /// </summary>
        /// <param name="connectionName">The connection name.</param>
        /// <param name="search">The search string to use.</param>
        /// <returns>An IEnumerable of User instances.</returns>
        public Page<User> GetUsersByConnection(string connectionName, string search, int pageSize = 0)
        {
            var request = new RestRequest("/api/connections/{connectionName}/users");
            request.AddParameter("connectionName", connectionName, ParameterType.UrlSegment);

            if (!string.IsNullOrEmpty(search))
            {
                request.AddParameter("search", search);
            }

            if (pageSize > 0)
            {
                request.AddParameter("per_page", pageSize);
            }

            return LoadPagedResource<User>(request);
        }

        /// <summary>
        /// Gets the first page of users available in social connections.
        /// If the connection doesn't have a directory or it is a social connection like 
        /// Google OAuth 2 it will return all the users that have logged in to your 
        /// application at least once.
        /// </summary>
        /// <returns>An IEnumerable of User instances.</returns>
        public Page<User> GetSocialUsers(int pageSize = 0)
        {
            return this.GetSocialUsers(string.Empty, pageSize);
        }

        /// <summary>
        /// Gets the first page of users available in social connections that match a search string.
        /// If the connection doesn't have a directory or it is a social connection like 
        /// Google OAuth 2 it will return all the users that have logged in to your 
        /// application at least once.
        /// </summary>
        /// <param name="search">The search string to use.</param>
        /// <returns>An IEnumerable of User instances.</returns>
        public Page<User> GetSocialUsers(string search, int pageSize = 0)
        {
            return this.GetUsers("socialconnections", search, pageSize);
        }

        /// <summary>
        /// Gets the first page of users available in enterprise connections.
        /// If the connection doesn't have a directory or it is a social connection like 
        /// Google OAuth 2 it will return all the users that have logged in to your 
        /// application at least once.
        /// </summary>
        /// <returns>An IEnumerable of User instances.</returns>
        public Page<User> GetEnterpriseUsers(int pageSize = 0)
        {
            return this.GetEnterpriseUsers(string.Empty, pageSize);
        }

        /// <summary>
        /// Gets the first page of users available in enterprise connections that match a search string.
        /// If the connection doesn't have a directory or it is a social connection like 
        /// Google OAuth 2 it will return all the users that have logged in to your 
        /// application at least once.
        /// </summary>
        /// <param name="search">The search string to use.</param>
        /// <returns>An IEnumerable of User instances.</returns>
        public Page<User> GetEnterpriseUsers(string search, int pageSize = 0)
        {
            return this.GetUsers("enterpriseconnections", search, pageSize);
        }

        /// <summary>
        /// Asks the server an access token, providing an authorization code.
        /// </summary>
        /// <param name="code">The authorization code received.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        /// <returns>An instance of TokenResult containing the access token.</returns>
        public TokenResult ExchangeAuthorizationCodePerAccessToken(string code, string redirectUri)
        {
            var request = new RestRequest("/oauth/token", Method.POST);

            request.AddHeader("accept", "application/json");

            request.AddParameter("client_id", this.clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", this.GetClientSecretOrThrow(), ParameterType.GetOrPost);
            request.AddParameter("code", code, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "authorization_code", ParameterType.GetOrPost);
            request.AddParameter("redirect_uri", redirectUri, ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new OAuthException(
                    "The Auth0 API did not return a complete response; ResponseStatus=" + response.ResponseStatus + "; ErrorMessage=" + response.ErrorMessage ?? string.Empty, 
                    string.Empty);
            }

            var body = response.Data;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var errorDescription = (body != null && body.ContainsKey("error_description")) ? body["error_description"] : "(no description)";
                errorDescription += "; StatusCode=" + (int)response.StatusCode;
                var errorCode = (body != null && body.ContainsKey("error")) ? body["error"] : string.Empty;

                throw new OAuthException(errorDescription, errorCode);
            }

            return new TokenResult
            {
                AccessToken = body["access_token"],
                IdToken = body.ContainsKey("id_token") ? body["id_token"] : string.Empty
            };
        }

        /// <summary>
        /// Gets user information from an access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>An instance of UserProfile contaning the user information.</returns>
        [ObsoleteAttribute("This method is obsolete. Call GetUserInfo(TokenResult tokenResult) instead.")]
        public UserProfile GetUserInfo(string accessToken)
        {
            return this.GetUserInfo(new TokenResult { AccessToken = accessToken });
        }

        /// <summary>
        /// Gets user information from an token result.
        /// </summary>
        /// <param name="tokenResult">The token result.</param>
        /// <returns>An instance of UserProfile contaning the user information.</returns>
        public UserProfile GetUserInfo(TokenResult tokenResult)
        {
            if (tokenResult == null)
            {
                throw new ArgumentNullException("tokenResult");
            }

            var jsonProfile = !string.IsNullOrEmpty(tokenResult.IdToken) ?
                this.GetJsonProfileFromIdToken(tokenResult.IdToken) :
                this.GetJsonProfileFromAccessToken(tokenResult.AccessToken);

            var userProfile = this.GetUserProfileFromJson(jsonProfile);

            if (string.IsNullOrEmpty(userProfile.UserId))
            {
                return this.GetUserInfo(new TokenResult { AccessToken = tokenResult.AccessToken });
            }

            return userProfile;
        }

        /// <summary>
        /// Gets user information from the internal id (_id).
        /// </summary>
        /// <param name="userId">The internal id.</param>
        /// <returns>An instance of UserProfile contaning the user information.</returns>
        public UserProfile GetUser(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("internalId");
            }

            var request = new RestRequest("/api/users/{userId}?access_token={accessToken}");
            var accessToken = this.GetAccessToken();
            request.AddHeader("accept", "application/json");
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            var response = this.client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(response));
            }

            var userProfile = this.GetUserProfileFromJson(response.Content);

            return userProfile;
        }

        private UserProfile GetUserProfileFromJson(string jsonProfile)
        {
            var ignoredProperties = new HashSet<string> { "iss", "sub", "aud", "exp", "iat" };
            var mappedProperties = new HashSet<string> 
            {
                "email",
                "family_name",
                "gender",
                "given_name",
                "locale",
                "name",
                "nickname",
                "picture",
                "user_id",
                "identities"
            };

            ignoredProperties.UnionWith(mappedProperties);

            var userProfile = JsonConvert.DeserializeObject<UserProfile>(jsonProfile);
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonProfile);

            userProfile.ExtraProperties = responseData != null ?
                ConvertJArrayToStringArray(ExcludeKeys(responseData, ignoredProperties)) :
                new Dictionary<string, object>();

            if (userProfile.Identities == null)
            {
                userProfile.Identities = Enumerable.Empty<UserProfile.Identity>();
            }

            object identities;

            if (responseData.TryGetValue("identities", out identities))
            {
                var identitiesExtraPropertiesStringArray = identities as JArray;

                if (identitiesExtraPropertiesStringArray != null)
                {
                    DeserializeIdentityExtraProperties(userProfile, identitiesExtraPropertiesStringArray);
                }
            }

            return userProfile;
        }

        private static Dictionary<string, object> ExcludeKeys(Dictionary<string, object> dictionary, HashSet<string> toExclude)
        {
            return dictionary.Where(kvp => !toExclude.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private static Dictionary<string, object> ConvertJArrayToStringArray(Dictionary<string, object> extraProperties)
        {
            return extraProperties.Select(kvp =>
            {
                if (kvp.Value is JArray)
                {
                    return new KeyValuePair<string, object>(kvp.Key, ((JArray)kvp.Value).Select(v => v.ToString()).ToArray());
                }

                return kvp;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private static void DeserializeIdentityExtraProperties(
            UserProfile userProfile,
            JArray identitiesExtraPropertiesStringArray)
        {
            if (!userProfile.Identities.Any())
            {
                return;
            }

            var identitiesMappedProperties = new HashSet<string>{
                    "access_token",
                    "provider",
                    "user_id",
                    "connection",
                    "isSocial"
                };

            // Get Extra Properties for each Identity Provider
            var identitiesList = userProfile.Identities.ToList();

            for (int i = 0; i < identitiesList.Count; i++)
            {
                var item = identitiesList[i];

                var identityExtraProperties = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                    identitiesExtraPropertiesStringArray[i].ToString());

                item.ExtraProperties = identityExtraProperties != null ?
                    ConvertJArrayToStringArray(ExcludeKeys(identityExtraProperties, identitiesMappedProperties)) :
                    new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Gets a delegation token.
        /// </summary>
        /// <param name="token">The current access token.</param>
        /// <param name="targetClientId">The client id of the target application.</param>
        /// <param name="scope">The openid scope.</param>
        /// <returns>An instance of DelegationTokenResult containing the delegation token id.</returns>
        public DelegationTokenResult GetDelegationToken(string token, string targetClientId, string scope = "passthrough")
        {
            var request = new RestRequest("/delegation", Method.POST);

            request.AddHeader("accept", "application/json");

            request.AddParameter("client_id", this.clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", this.GetClientSecretOrThrow(), ParameterType.GetOrPost);
            request.AddParameter("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer", ParameterType.GetOrPost);
            request.AddParameter("id_token", token, ParameterType.GetOrPost);
            request.AddParameter("target", targetClientId, ParameterType.GetOrPost);
            request.AddParameter("scope", scope, ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request).Data;

            if (response.ContainsKey("error") || response.ContainsKey("error_description"))
            {
                throw new OAuthException(response["error_description"], response["error"]);
            }

            return new DelegationTokenResult
            {
                IdToken = response.ContainsKey("id_token") ? response["id_token"] : string.Empty,
                TokenType = response.ContainsKey("token_type") ? response["token_type"] : null,
                ValidFrom = DateTime.UtcNow,
                ValidTo = response.ContainsKey("expires_in") ? DateTime.UtcNow.AddSeconds(int.Parse(response["expires_in"])) : DateTime.MaxValue
            };
        }

        /// <summary>
        /// Logs a user with username/password (active authentication).
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="connection">The connection name.</param>
        /// <param name="scope">The openid scope.</param>
        /// <returns></returns>
        public TokenResult LoginUser(
            string username, string password, string connection, string scope = "openid")
        {
            var request = new RestRequest("/oauth/ro", Method.POST);

            request.AddHeader("accept", "application/json");

            request.AddParameter("client_id", this.clientID, ParameterType.GetOrPost);
            request.AddParameter("username", username, ParameterType.GetOrPost);
            request.AddParameter("password", password, ParameterType.GetOrPost);
            request.AddParameter("connection", connection, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            request.AddParameter("scope", scope, ParameterType.GetOrPost);

            var result = this.client.Execute<Dictionary<string, string>>(request);
            var response = result.Data;
            if (response.ContainsKey("error") || response.ContainsKey("error_description"))
            {
                throw new OAuthException(response["error_description"], response["error"]);
            }

            return new TokenResult
            {
                AccessToken = response["access_token"],
                IdToken = response.ContainsKey("id_token") ? response["id_token"] : string.Empty
            };
        }

        /// <summary>
        /// Updates a user metadata. Existing metadata will not be modified or deleted
        /// unless new data is provided with the same key.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="metadata">An object that contains the metadata to set for the user.</param>
        public void UpdateUserMetadata(string userId, object metadata)
        {
            this.UpdateUserMetadataInternal(Method.PATCH, userId, metadata);
        }

        /// <summary>
        /// Updates a user metadata. Existing metadata will not be modified or deleted
        /// unless new data is provided with the same key.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="metadata">An object that contains the metadata to set for the user.</param>
        public void UpdateUserMetadata(string userId, IDictionary<string, object> metadata)
        {
            this.UpdateUserMetadataInternal(Method.PATCH, userId, metadata);
        }

        /// <summary>
        /// Block a user by setting block metadata to true
        /// </summary>
        /// <param name="userId">The userId to be blocked</param>
        public void BlockUser(string userId)
        {
            this.PatchUser(userId, new { blocked = true });
        }

        /// <summary>
        /// Unblock a user by setting block metadata to false
        /// </summary>
        /// <param name="userId">The userId to be unblocked</param>
        public void UnblockUser(string userId)
        {
            this.PatchUser(userId, new { blocked = false });
        }

        /// <summary>
        /// Sets user metadata. All existing metadata will be replaced with
        /// the data provided here.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="metadata">An object that contains the metadata to set for the user.</param>
        public void SetUserMetadata(string userId, object metadata)
        {
            this.UpdateUserMetadataInternal(Method.PUT, userId, metadata);
        }

        /// <summary>
        /// Sets user metadata. All existing metadata will be replaced with
        /// the data provided here.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="metadata">An object that contains the metadata to set for the user.</param>
        public void SetUserMetadata(string userId, IDictionary<string, object> metadata)
        {
            this.UpdateUserMetadataInternal(Method.PUT, userId, metadata);
        }

        private void PatchUser(string userId, object changes)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            if (changes == null)
            {
                throw new ArgumentNullException("metadata");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "?access_token=" + accessToken, Method.PATCH);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(changes);

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        private void UpdateUserMetadataInternal(Method method, string userId, object metadata)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/metadata?access_token=" + accessToken, method);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(metadata);

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(string email, string password, string connection, bool emailVerified)
        {
            return CreateUser(email, password, connection, emailVerified, null);
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="identifier">The user's identifier.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(UserIdentifier identifier, string password, string connection, bool emailVerified)
        {
            return this.CreateUser(identifier, password, connection, emailVerified, null);
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <param name="metadata">Additional metadata to include in the user's profile.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(
            string email, string password, string connection, bool emailVerified, IDictionary<string, object> metadata)
        {
            return this.CreateUser(email, password, connection, emailVerified, (object)metadata);
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="identifier">The user's identifier.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <param name="metadata">Additional metadata to include in the user's profile.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(UserIdentifier identifier, string password, string connection, bool emailVerified, IDictionary<string, object> metadata)
        {
            return this.CreateUser(identifier, password, connection, emailVerified, (object)metadata);
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <param name="metadata">Additional metadata to include in the user's profile.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(string email, string password, string connection, bool emailVerified, object metadata)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            return this.CreateUser(UserIdentifier.Email(email), password, connection, emailVerified, metadata);
        }

        /// <summary>
        /// Creates a new user (only valid for database connections).
        /// </summary>
        /// <param name="identifier">The user's identifier.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="connection">The name of the database connection to store the user.</param>
        /// <param name="emailVerified">True if the emails is already verified, false if a verification message is required.</param>
        /// <param name="metadata">Additional metadata to include in the user's profile.</param>
        /// <returns>The profile of the user created.</returns>
        public UserProfile CreateUser(UserIdentifier identifier, string password, string connection, bool emailVerified, object metadata)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentNullException("connection");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/?access_token=" + accessToken, Method.POST);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            var requestBodyDict = metadata == null
                                  ? new Dictionary<string, object>()
                // from object to json and back to dictionary
                                  : JsonConvert.DeserializeObject<Dictionary<string, object>>(
                                      JsonConvert.SerializeObject(metadata));
            requestBodyDict[identifier.Type.ToString().ToLowerInvariant()] = identifier.Value;
            requestBodyDict["password"] = password;
            requestBodyDict["connection"] = connection;
            requestBodyDict["email_verified"] = emailVerified;
            request.AddBody(requestBodyDict);

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
            var userProfile = GetUserProfileFromJson(result.Content);

            return userProfile;
        }

        /// <summary>
        /// Changes a user password (only for database connections).
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPassword">The new password to set.</param>
        /// <param name="verify">True if a verification email message is required, false otherwise.</param>
        public void ChangePassword(string userId, string newPassword, bool verify)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentNullException("newPassword");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/password?access_token=" + accessToken, Method.PUT);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { password = newPassword, verify = verify });

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Changes a user password (only for database connections).
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="newPassword">The new password to set.</param>
        /// <param name="connection">The name of the connection in which the user exists.</param>
        /// <param name="verify">True if a verification email message is required, false otherwise.</param>
        public void ChangePassword(string email, string newPassword, string connection, bool verify)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentNullException("newPassword");
            }

            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentNullException("connection");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + email + "/password?access_token=" + accessToken, Method.PUT);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { password = newPassword, verify, email, connection });

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Changes a user email (the email used to login)
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newEmail">The new email to set.</param>
        public void ChangeEmail(string userId, string newEmail, bool verify)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            if (string.IsNullOrEmpty(newEmail))
            {
                throw new ArgumentNullException("newEmail");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/email?access_token=" + accessToken, Method.PUT);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { email = newEmail, verify = verify });

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Unlink an identity from the primary account/identity
        /// </summary>
        /// <param name="userId">the userId that must be unlinked in the provider|id format</param>
        /// <param name="accessToken">primary identity access token</param>
        public void Unlink(string userId, string accessToken)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var request = new RestRequest("/unlink", Method.POST);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new { access_token = accessToken, user_id = userId, clientID = clientID });

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="userId">The id of the user to delete.</param>
        public void DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "?access_token=" + accessToken, Method.DELETE);

            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        public void SendVerificationEmail(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/send_verification_email?access_token=" + accessToken, Method.POST);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            var result = this.client.Execute(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }
        }

        /// <summary>
        /// Generates change password ticket.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPassword"></param>
        /// <param name="resultUrl">Post verification url</param>
        /// <returns></returns>
        public string GenerateChangePasswordTicket(string userId, string newPassword, string resultUrl = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/change_password_ticket?access_token=" + accessToken, Method.POST);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.AddParameter("newPassword", newPassword, ParameterType.GetOrPost);

            if (!string.IsNullOrEmpty(resultUrl))
            {
                request.AddParameter("resultUrl", resultUrl, ParameterType.GetOrPost);
            }

            var result = this.client.Execute<Dictionary<string, string>>(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }

            return result.Data["ticket"];
        }

        /// <summary>
        /// Generates verification ticket.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="resultUrl">Post verification url</param>
        /// <returns></returns>
        public string GenerateVerificationTicket(string userId, string resultUrl = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }

            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/users/" + userId + "/verification_ticket?access_token=" + accessToken, Method.POST);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();

            if (!string.IsNullOrEmpty(resultUrl))
            {
                request.AddParameter("resultUrl", resultUrl, ParameterType.GetOrPost);
            }

            var result = this.client.Execute<Dictionary<string, string>>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }

            return result.Data["ticket"];
        }

        /// <summary>
        /// Validate the username and password for a specific connection.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="connection">The connection name.</param>
        public UserValidationResult ValidateUser(string username, string password, string connection)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentNullException("connection");
            }

            var request = new RestRequest("/public/api/users/validate_userpassword", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("connection", connection);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("client_id", clientID);

            var result = this.client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException(GetErrorDetails(result));
            }

            return new UserValidationResult
            {
                IsValid = result.StatusCode == HttpStatusCode.OK,
                Message = result.Content
            };
        }

        private static string GetErrorDetails(IRestResponse response)
        {
            var detail = response.Content ?? "No error details available";

            return string.Format("{0} - {1}", response.StatusDescription, detail);
        }

        private string GetJsonProfileFromIdToken(string idToken)
        {
            return Encoding.UTF8.GetString(
                Utils.Base64UrlDecode(
                    idToken.Split('.')[1]));
        }

        private string GetJsonProfileFromAccessToken(string accessToken)
        {
            var request = new RestRequest("/userinfo?access_token={accessToken}");
            request.AddHeader("accept", "application/json");
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            var response = this.client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new InvalidOperationException(GetErrorDetails(response));
            }

            return response.Content;
        }

        private string GetAccessToken()
        {
            if (this.currentToken != null && this.currentToken.RetrievedIn + TimeSpan.FromHours(10) > DateTime.Now)
            {
                return this.currentToken.Token;
            }

            var request = new RestRequest("/oauth/token", Method.POST);

            request.AddHeader("accept", "application/json");
            request.AddParameter("client_id", this.clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", this.GetClientSecretOrThrow(), ParameterType.GetOrPost);
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ArgumentException("invalid clientid, secret or domain");
            }
            else if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotModified)
            {
                throw new InvalidOperationException(GetErrorDetails(response));
            }

            var tk = response.Data["access_token"];
            this.currentToken = new AccessToken(DateTime.Now, tk);

            return this.currentToken.Token;
        }

        private Page<Connection> GetConnectionsInternal(bool onlySocials = false, bool onlyEnterprise = false, int pageSize = 0)
        {
            var request = new RestRequest("/api/connections");
            request.AddParameter("only_socials", onlySocials);
            request.AddParameter("only_enterprise", onlyEnterprise);

            if (pageSize > 0)
            {
                request.AddParameter("per_page", pageSize);
            }

            return LoadPagedResource<Connection>(request);
        }

        private Page<User> GetUsers(string connectionType, string search, int pageSize = 0)
        {
            if (string.IsNullOrEmpty(connectionType))
            {
                throw new ArgumentNullException("connectionType");
            }

            var request = new RestRequest("/api/{connectionType}/users");
            request.AddParameter("connectionType", connectionType, ParameterType.UrlSegment);

            if (!string.IsNullOrEmpty(search))
            {
                request.AddParameter("search", search);
            }

            if (pageSize > 0)
            {
                request.AddParameter("per_page", pageSize);
            }

            return LoadPagedResource<User>(request);
        }

        private Page<T> LoadPagedResource<T>(RestRequest request)
        {
            var accessToken = GetAccessToken();
            request.AddParameter("access_token", accessToken);

            request.AddHeader("accept", "application/json");

            var response = client.Execute(request);
            return BuildPage<T>(response);
        }

        private Page<T> LoadPageFromLink<T>(string url)
        {
            var request = new RestRequest(new Uri(url));
            request.AddHeader("accept", "application/json");

            var response = this.client.Execute(request);
            return BuildPage<T>(response);
        }

        private Page<T> BuildPage<T>(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(
                    string.Format("A non-success status code of '{0}' was returned, with response '{1}'", response.StatusCode, response.Content));
            }

            var results = JsonConvert.DeserializeObject<List<T>>(response.Content);
            var links = ParseLinks(response.Headers.FirstOrDefault(h => h.Name == "Link"));

            if (!links.ContainsKey("next"))
            {
                return new Page<T>(results, false, null);
            }

            return new Page<T>(results, true, () => LoadPageFromLink<T>(links["next"]));
        }

        /// <summary>
        /// Given the 'Links' header will parse the links that have been returned from the API.
        /// </summary>
        /// <param name="linksHeader">The links header, which may be null or contain an empty string.</param>
        /// <returns>A dictionary of links, with the key being the <c>rel</c> and the value the URL.</returns>
        private Dictionary<string, string> ParseLinks(Parameter linksHeader)
        {
            if (linksHeader == null || linksHeader.Value == null || string.IsNullOrEmpty(linksHeader.Value.ToString()))
            {
                return new Dictionary<string, string>();
            }

            var entries = linksHeader.Value.ToString().Split(',');

            return entries.ToDictionary(
                e => Regex.Match(e, "rel=\"(.*)\"").Groups[1].Value,
                e => Regex.Match(e, "<(.*)>").Groups[1].Value);
        }

    }
}
