using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortableRest;

namespace Auth0.Api.Management
{
    public class ApiConnection : RestClient, IApiConnection
    {
        private readonly string token;

        public ApiConnection(string token, string baseUrl)
        {
            this.token = token;
            BaseUrl = baseUrl;
        }

        public async Task<T> GetAsync<T>(string resource, IDictionary<string, string> parameters, string accepts) where T : class
        {
            var request = new RestRequest(resource);
            
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            var response = await SendAsync<T>(request).ConfigureAwait(false);

            return response.Content;
        }
    }
}