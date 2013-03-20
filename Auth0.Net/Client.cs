using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace Auth0
{
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
            client = new RestClient(url);
        }


        private string GetAccessToken()
        {
            if (currentToken != null && currentToken.RetrievedIn + TimeSpan.FromHours(10) > DateTime.Now)
            {
                return currentToken.Token;
            }

            var request = new RestRequest("/oauth/token", Method.POST);

            request.AddHeader("accept", "application/json");
            request.AddParameter("client_id", clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

            var response = client.Execute<Dictionary<string, string>>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ArgumentException("invalid clientid, secret or domain");
            }

            var tk = response.Data["access_token"];
            currentToken = new AccessToken(DateTime.Now, tk);
            return currentToken.Token;
        }

        private IEnumerable<Connection> GetConnectionsInternal(bool onlySocials = false, bool onlyEnterprise = false)
        {
            var accessToken = GetAccessToken();

            var request = new RestRequest("/api/connections");
            request.AddParameter("access_token", accessToken);
            request.AddParameter("only_socials", onlySocials);
            request.AddParameter("only_enterprise", onlyEnterprise);

            var response = client.Execute<List<Connection>>(request);
            return response.Data;
        }


        public IEnumerable<Connection> GetConnections()
        {
            return GetConnectionsInternal();
        }

        public IEnumerable<Connection> GetSocialConnections()
        {
            return GetConnectionsInternal(onlySocials: true);
        }

        public IEnumerable<Connection> GetEnterpriseConnections()
        {
            return GetConnectionsInternal(onlyEnterprise: true);
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
                var connection = CreateConnection(connectionTicket);
                return new CreateConnectionResult() {
                    worked = true,
                    provisioning_ticket_url = connection.ProvisioningTicketUrl
                };
            }
            catch (Exception ex)
            {
                return new CreateConnectionResult() {
                    worked = false,
                    error = ex.Message
                };
            }
        }

        public Connection CreateConnection(Connection ticket)
        {
            var accessToken = GetAccessToken();

            var request = new RestRequest("/api/connections?access_token=" + accessToken, Method.POST);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
            
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(ticket);

            var result = client.Execute(request);
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var detail = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Content)["detail"];
                throw new ArgumentException(detail);
            }
            return JsonConvert.DeserializeObject<Connection>(result.Content);
        }

        public void DeleteConnection(string connectionName)
        {
            var accessToken = GetAccessToken();
            var request = new RestRequest("/api/connections/{name}?access_token={accessToken}", Method.DELETE);
            
            request.AddParameter("name", connectionName, ParameterType.UrlSegment);
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            client.Execute(request);
        }
        
        public IEnumerable<User> GetUsersByConnection(string connectionName)
        {
            var accessToken = GetAccessToken();
            var request = new RestRequest("/api/connections/{connectionName}/users?access_token={accessToken}");
            
            request.AddHeader("accept", "application/json");
            request.AddParameter("connectionName", connectionName, ParameterType.UrlSegment);
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<User>>(response.Content);
        }

        public IEnumerable<User> GetSocialUsers()
        {
            var accessToken = GetAccessToken();
            var request = new RestRequest("/api/socialconnections/users?access_token={accessToken}");
            
            request.AddHeader("accept", "application/json");
            request.AddParameter("accessToken", accessToken, ParameterType.UrlSegment);

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<User>>(response.Content);
        }


        public TokenResult ExchangeAuthorizationCodePerAccessToken(string code, string redirectUri)
        {
            var request = new RestRequest("/oauth/token");
            
            request.AddHeader("accept", "application/json");
         
            request.AddParameter("client_id", clientID, ParameterType.GetOrPost);
            request.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
            request.AddParameter("code", code, ParameterType.GetOrPost);
            request.AddParameter("grant_type", "authorization_code", ParameterType.GetOrPost);
            request.AddParameter("redirect_uri", redirectUri, ParameterType.GetOrPost);

            var response = client.Execute<Dictionary<string, string>>(request).Data;

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

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<UserProfile>(response.Content);
        }

    }
}
