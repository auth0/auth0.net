using System;
using System.Collections.Generic;
using System.Net;
using EasyHttp.Http;
using System.Dynamic;

namespace Auth0
{
    public class Client
    {
        private readonly string clientID;
        private readonly string clientSecret;
        private readonly string domain;
        private readonly string apiUrl;
        private AccessToken currentToken;

        public Client(string clientID, string clientSecret, string domain)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            this.domain = domain;
            this.apiUrl = "https://" + this.domain + "/api";
        }


        private string GetAccessToken()
        {
            if (currentToken != null && currentToken.RetrievedIn + TimeSpan.FromHours(10) > DateTime.Now)
            {
                return currentToken.Token;
            }

            var http = new HttpClient();
            
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            dynamic payload = new ExpandoObject();
            payload.client_id = clientID;
            payload.client_secret = clientSecret;
            payload.grant_type = "client_credentials";

            var result = http.Post("https://" + domain + "/oauth/token", payload , HttpContentTypes.ApplicationXWwwFormUrlEncoded);
            
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ArgumentException("invalid clientid, secret or domain");
            }

            var tk = result.DynamicBody.access_token;
            this.currentToken = new AccessToken(DateTime.Now, tk);
            return this.currentToken.Token;
        }

        private IEnumerable<Connection> GetConnectionsInternal(bool onlySocials = false, bool onlyEnterprise = false)
        {
            var accessToken = GetAccessToken();
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var result = http.Get(apiUrl + "/connections", new
            {
                access_token = accessToken,
                only_socials = onlySocials,
                only_enterprise = onlyEnterprise
            });

            return result.StaticBody<List<Connection>>();
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

        public Connection CreateConnection(Connection ticket)
        {
            var accessToken = GetAccessToken();
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var result = http.Post(apiUrl + "/connections", 
                ticket, 
                HttpContentTypes.ApplicationJson, 
                new { access_token = accessToken });

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
    }
}
