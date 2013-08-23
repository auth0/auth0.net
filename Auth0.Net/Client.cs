using System.IO;

namespace Auth0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;
    using Newtonsoft.Json.Linq;

    public class Client
    {
        private static readonly Regex NextRelLinkRegex = new Regex("<(?<url>.*)>.*rel=\"next\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly string clientID;
        private readonly string clientSecret;
        private readonly string domain;
        private AccessToken currentToken;
        private RestClient client;

        public Client(string clientID, string clientSecret, string domain)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            this.domain = domain;
            var url = "https://" + this.domain;
            this.client = new RestClient(url);
        }

        public Page<Connection> GetConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(pageSize: pageSize);
        }

        public Page<Connection> GetSocialConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(onlySocials: true, pageSize: pageSize);
        }

        public Page<Connection> GetEnterpriseConnections(int pageSize = 0)
        {
            return this.GetConnectionsInternal(onlyEnterprise: true, pageSize: pageSize);
        }

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

        public void DeleteConnection(string connectionName)
        {
            var accessToken = this.GetAccessToken();
            var request = new RestRequest("/api/connections/{name}?access_token={accessToken}", Method.DELETE);
            
            request.AddParameter("name", connectionName, ParameterType.UrlSegment);
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            this.client.Execute(request);
        }

        public Page<User> GetUsersByConnection(string connectionName, int pageSize = 0)
        {
            return this.GetUsersByConnection(connectionName, string.Empty, pageSize);
        }

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

        public Page<User> GetSocialUsers(int pageSize = 0)
        {
            return this.GetSocialUsers(string.Empty, pageSize);
        }

        public Page<User> GetSocialUsers(string search, int pageSize = 0)
        {
            return this.GetUsers("socialconnections", search, pageSize);
        }

        public Page<User> GetEnterpriseUsers(int pageSize = 0)
        {
            return this.GetEnterpriseUsers(string.Empty, pageSize);
        }

        public Page<User> GetEnterpriseUsers(string search, int pageSize = 0)
        {
            return this.GetUsers("enterpriseconnections", search, pageSize);
        }

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