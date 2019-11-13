using Auth0.Core.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    internal class ApiConnectionBridge : IApiConnection
    {
        private readonly string _baseUrl;
        private readonly IManagementConnection _connection;
        private readonly string _token;

        public ApiConnectionBridge(string token, string baseUrl, IManagementConnection connection)
        {
            _token = token;
            _baseUrl = baseUrl;
            _connection = connection;
        }

        public async Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete,
                null,
                urlSegments,
                queryStrings,
                null,
                null,
                null,
                null).ConfigureAwait(false);
        }

        public async Task<T> DeleteAsync<T>(string resource, object body, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete,
                body,
                urlSegments,
                queryStrings,
                null,
                null,
                null,
                null).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers,
            params JsonConverter[] converters) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Get,
                null,
                urlSegments,
                queryStrings,
                null,
                headers,
                null,
                converters).ConfigureAwait(false);
        }

        public async Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments)
            where T : class
        {
            return await RunAsync<T>(resource,
                new HttpMethod("PATCH"),
                body,
                urlSegments,
                null,
                null,
                null,
                null,
                null).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters,
            IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments,
            IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Post,
                body,
                urlSegments,
                queryStrings,
                parameters,
                headers,
                fileParameters,
                null).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(string resource, object body, IDictionary<string, object> parameters,
            IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments,
            IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Put,
                body,
                urlSegments,
                queryStrings,
                parameters,
                headers,
                fileParameters,
                null).ConfigureAwait(false);
        }

        private Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, object body,
            IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings,
            IDictionary<string, object> parameters, IDictionary<string, object> headers,
            IList<FileUploadParameter> fileParameters, params JsonConverter[] converters) where T : class
        {
            var finalUrl = Utils.BuildUri(_baseUrl, resource, urlSegments, queryStrings);

            var stringHeaders = headers.ToDictionary(h => h.Key, h => h.Value.ToString());

            return _connection.SendAsync<T>(httpMethod, finalUrl, body ?? parameters, stringHeaders, fileParameters);
        }
    }
}
