using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

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
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var result = http.Post(apiUrl + "/connections", 
                ticket, 
                HttpContentTypes.ApplicationJson, 
                new { access_token = accessToken });
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException(result.StaticBody<Dictionary<string, string>>()["detail"]);
            }
            return result.StaticBody<Connection>();
        }

        public void DeleteConnection(string connectionName)
        {
            var accessToken = GetAccessToken();
            var http = new HttpClient();
            http.Delete(apiUrl + "/connections/" + connectionName,
                new { access_token = accessToken });
        }
        
        public IEnumerable<User> GetUsersByConnection(string connectionName)
        {
            var accessToken = GetAccessToken();
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var result = http.Get(apiUrl + "/connections/" + connectionName + "/users", new
            {
                access_token = accessToken
            });

            return result.StaticBody<List<User>>();
        }

        public IEnumerable<User> GetSocialUsers()
        {
            var accessToken = GetAccessToken();
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var result = http.Get(apiUrl + "/socialconnections/users", new
            {
                access_token = accessToken
            });

            return result.StaticBody<List<User>>();
        }


        public string ExchangeAuthorizationCodePerAccessToken(string code, string redirectUri)
        {
            var http = new HttpClient();

            var payload = new Dictionary<string, string>{
                {"client_id",       clientID},
                {"client_secret",   clientSecret},
                {"code",            code},
                {"grant_type",      "authorization_code"},
                {"redirect_uri",    redirectUri}
            };

            var tokenResult = http.Post("https://" + this.domain + "/oauth/token", payload, "application/json");

            return tokenResult.StaticBody<Dictionary<string, string>>()["access_token"];
        }

        public UserProfile GetUserInfo(string accessToken)
        {
            var url = "https://" + this.domain + "/userinfo";
            var http = new HttpClient();
            var response = http.Get(url, new { access_token = accessToken });
            var result = response.StaticBody<UserProfile>();
            return result;
        }

    }
}
