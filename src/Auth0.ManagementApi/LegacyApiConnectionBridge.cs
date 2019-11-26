using Auth0.Core.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    // Temporary class to help break commits apart.
    // TODO: Remove before shipping.
    internal class LegacyApiConnectionBridge : IApiConnection
    {
        private readonly string baseUrl;
        private readonly IManagementConnection connection;

        public LegacyApiConnectionBridge(string baseUrl, IManagementConnection connection)
        {
            this.baseUrl = baseUrl;
            this.connection = connection;
        }

        public Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return RunAsync<T>(resource,
                HttpMethod.Delete,
                null,
                urlSegments,
                queryStrings
            );
        }

        public Task<T> DeleteAsync<T>(string resource, object body, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return RunAsync<T>(resource,
                HttpMethod.Delete,
                body,
                urlSegments,
                queryStrings
             );
        }

        public Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers,
            params JsonConverter[] converters) where T : class
        {
            var finalUrl = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
            var stringHeaders = headers?.ToDictionary(h => h.Key, h => h.Value.ToString());

            return connection.GetAsync<T>(finalUrl, null, converters);
        }

        public Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class
        {
            return RunAsync<T>(resource,
                new HttpMethod("PATCH"),
                body,
                urlSegments
            );
        }

        public Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters,
            IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments,
            IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return RunAsync<T>(resource,
                HttpMethod.Post,
                body,
                urlSegments,
                queryStrings,
                parameters,
                headers,
                fileParameters
            );
        }

        public Task<T> PutAsync<T>(string resource, object body, IDictionary<string, object> parameters,
            IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments,
            IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return RunAsync<T>(resource,
                HttpMethod.Put,
                body,
                urlSegments,
                queryStrings,
                parameters,
                headers,
                fileParameters
            );
        }

        private Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, object body,
            IDictionary<string, string> urlSegments = null, IDictionary<string, string> queryStrings = null,
            IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null,
            IList<FileUploadParameter> fileParameters = null) where T : class
        {
            var finalUrl = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
            var stringHeaders = headers?.ToDictionary(h => h.Key, h => h.Value.ToString());

            return connection.SendAsync<T>(httpMethod, finalUrl, body ?? parameters, stringHeaders, fileParameters);
        }
    }
}
