
namespace Auth0
{
	using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Provides access to Auth0 services.
    /// </summary>
    public class Client
    {
        private static readonly Regex NextRelLinkRegex = new Regex("<(?<url>.*)>.*rel=\"next\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly string clientID;
        private readonly string clientSecret;
        private readonly string domain;
        private AccessToken currentToken;
        private readonly RestClient client;

        /// <summary>
        /// Creates an instance of the client.
        /// </summary>
        /// <param name="clientID">The client id of the application, as shown in the dashboard settings.</param>
        /// <param name="clientSecret">The client secret of the application, as shown in the dashboard settings.</param>
        /// <param name="domain">The domain for the Auth0 server.</param>
        public Client(string clientID, string clientSecret, string domain)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            this.domain = domain;
            string url = "https://" + this.domain;
            this.client = new RestClient(url);
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

            if (provisioningTicket.options.ContainsKey("adfs_server") &&
                !string.IsNullOrEmpty(provisioningTicket.options["adfs_server"]))
            {
                connectionTicket.Options.AdfsServer = provisioningTicket.options["adfs_server"];
            }

            if (provisioningTicket.options.ContainsKey("server_url") &&
                !string.IsNullOrEmpty(provisioningTicket.options["server_url"]))
            {
                connectionTicket.Options.ServerUrl = provisioningTicket.options["server_url"];
            }

            try
            {
                var connection = this.CreateConnection(connectionTicket);
                return new CreateConnectionResult
                {
                    worked = true,
                    provisioning_ticket_url = connection.ProvisioningTicketUrl
                };
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
                var detail = GetErrorDetails(result.Content);
                throw new InvalidOperationException(
                    string.Format("{0} - {1}", result.StatusDescription, detail));
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
            request.AddParameter("client_secret", this.clientSecret, ParameterType.GetOrPost);
            request.AddParameter("code", code, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "authorization_code", ParameterType.GetOrPost);
            request.AddParameter("redirect_uri", redirectUri, ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request).Data;

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
        /// Gets user information from an access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>An instance of UserProfile contaning the user information.</returns>
        public UserProfile GetUserInfo(string accessToken)
        {
            var request = new RestRequest("/userinfo?access_token={accessToken}");

            request.AddHeader("accept", "application/json");
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            var response = this.client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new InvalidOperationException(GetErrorDetails(response.Content));
            }

            var mappedProperties = new string[] 
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

            var userProfile = JsonConvert.DeserializeObject<UserProfile>(response.Content);
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
            userProfile.ExtraProperties = responseData != null ?
                responseData.Keys.Where(x => !mappedProperties.Contains(x)).ToDictionary(x => x, x => responseData[x]) :
                new Dictionary<string, object>();

            // Convert JArray to string[]
            for (int i = 0; i < userProfile.ExtraProperties.Count; i++)
            {
                var item = userProfile.ExtraProperties.ElementAt(i);
                if (item.Value is JArray)
                {
                    var stringArray = ((JArray)item.Value).Select(v => v.ToString()).ToArray();
                    userProfile.ExtraProperties.Remove(item.Key);
                    userProfile.ExtraProperties.Add(item.Key, stringArray);
                }
            }

            return userProfile;
        }

        /// <summary>
        /// Gets a delegation token.
        /// </summary>
        /// <param name="token">The current access token.</param>
        /// <param name="targetClientId">The client id of the target application.</param>
        /// <returns>An instance of DelegationTokenResult containing the delegation token id.</returns>
        public DelegationTokenResult GetDelegationToken(string token, string targetClientId)
        {
            var request = new RestRequest("/delegation", Method.POST);

            request.AddHeader("accept", "application/json");

            request.AddParameter("client_id", this.clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", this.clientSecret, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer", ParameterType.GetOrPost);
            request.AddParameter("id_token", token, ParameterType.GetOrPost);
            request.AddParameter("target", targetClientId, ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request).Data;

            if (response.ContainsKey("error") || response.ContainsKey("error_description"))
            {
                throw new OAuthException(response["error_description"], response["error"]);
            }

            return new DelegationTokenResult
            {
                IdToken = response.ContainsKey("id_token") ? response["id_token"] : string.Empty
            };
        }

        private static string GetErrorDetails(string resultContent)
        {
            try
            {
                return JsonConvert.DeserializeObject(resultContent).ToString();
            }
            catch (JsonReaderException)
            {
            }

            return resultContent;
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
            request.AddParameter("client_secret", this.clientSecret, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

            var response = this.client.Execute<Dictionary<string, string>>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ArgumentException("invalid clientid, secret or domain");
            }
            else if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotModified)
            {
                throw new InvalidOperationException(
                    string.Format("{0} - {1}", response.StatusCode, GetErrorDetails(response.Content)));
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
            // URL is absolute, so we cannot use previously created client (it has a base URL)
            var client = new RestClient();
            var request = new RestRequest(url);
            request.AddHeader("accept", "application/json");

            var response = client.Execute(request);
            return BuildPage<T>(response);
        }

        private Page<T> BuildPage<T>(IRestResponse response)
        {
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