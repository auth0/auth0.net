namespace Auth0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;

    public class Client
    {
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

        public IEnumerable<Connection> GetConnections()
        {
            return this.GetConnectionsInternal();
        }

        public IEnumerable<Connection> GetSocialConnections()
        {
            return this.GetConnectionsInternal(onlySocials: true);
        }

        public IEnumerable<Connection> GetEnterpriseConnections()
        {
            return this.GetConnectionsInternal(onlyEnterprise: true);
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
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var detail = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Content)["detail"];
                throw new ArgumentException(detail);
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
        
        public IEnumerable<User> GetUsersByConnection(string connectionName)
        {
            var accessToken = this.GetAccessToken();
            var request = new RestRequest("/api/connections/{connectionName}/users?access_token={accessToken}");
            
            request.AddHeader("accept", "application/json");
            request.AddParameter("connectionName", connectionName, ParameterType.UrlSegment);
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            var response = this.client.Execute(request);

            return JsonConvert.DeserializeObject<List<User>>(response.Content);
        }

        public IEnumerable<User> GetSocialUsers(string search = "")
        {
            return this.GetUsers("socialconnections", search);
        }

        public IEnumerable<User> GetEnterpriseUsers(string search = "")
        {
            return this.GetUsers("enterpriseconnections", search);
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

            var response = this.client.Execute<Dictionary<string, string>>(request);

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
            userProfile.ExtraProperties = response.Data.Keys.Where(x => !mappedProperties.Contains(x))
                                    .ToDictionary(x => x, x => response.Data[x]);
            return userProfile;
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

            var tk = response.Data["access_token"];
            this.currentToken = new AccessToken(DateTime.Now, tk);

            return this.currentToken.Token;
        }

        private IEnumerable<Connection> GetConnectionsInternal(bool onlySocials = false, bool onlyEnterprise = false)
        {
            var accessToken = this.GetAccessToken();

            var request = new RestRequest("/api/connections");
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            request.AddParameter("access_token", accessToken);
            request.AddParameter("only_socials", onlySocials);
            request.AddParameter("only_enterprise", onlyEnterprise);

            var response = this.client.Execute(request);

            return JsonConvert.DeserializeObject<List<Connection>>(response.Content);
        }

        private IEnumerable<User> GetUsers(string connectionType, string search)
        {
            if (string.IsNullOrEmpty(connectionType))
            {
                throw new ArgumentNullException("connectionType");
            }

            var accessToken = this.GetAccessToken();
            var request = new RestRequest("/api/{connectionType}/users");

            request.AddHeader("accept", "application/json");
            request.AddParameter("connectionType", connectionType, ParameterType.UrlSegment);
            request.AddParameter("access_token", accessToken);

            if (!string.IsNullOrEmpty(search))
            {
                request.AddParameter("search", search);
            }

            var response = this.client.Execute(request);

            return JsonConvert.DeserializeObject<List<User>>(response.Content);
        }
    }
}