using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Interface for connectivity between <see cref="ManagementApiClient"/> and
    /// the remote server.
    /// </summary>
    /// <remarks>
    /// A default implementation of this using <see cref="HttpClient"/> is included as
    /// <see cref="HttpClientManagementConnection"/>.
    /// You should mock this interface to perform unit testing of code that uses
    /// <see cref="ManagementApiClient"/>.
    /// </remarks>
    public interface IManagementConnection
    {
        /// <summary>
        /// Sets the default headers that will be used by requests. This includes
        /// Authorization and the Auth0 User-Agent.
        /// </summary>
        /// <param name="headers"><see cref="Dictionary{string, string}"/> of header key/values to send with each request unless overrided on a per-request basis.</param>
        void SetDefaultHeaders(IDictionary<string, string> headers);

        /// <summary>
        /// Perform a HTTP GET operation against a given <see cref="Uri"/> and return the materialized response body as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result content as.</typeparam>
        /// <param name="uri"><see cref="Uri"/> to perform the GET request against.</param>
        /// <param name="headers">Optional <see cref="Dictionary{string, string}"/> containing additional headers that may override the defaults.</param>
        /// <param name="converters">Optional <see cref="JsonConverter[]"/> used to deserialize the resulting <typeparamref name="T"/>.</param>
        /// <returns><see cref="Task{T}"/> representing the async operation containing response body as <typeparamref name="T"/>.</returns>
        Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null);

        /// <summary>
        /// Perform a HTTP operation against a given <see cref="Uri"/> and return any materialized response body as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result content as.</typeparam>
        /// <param name="method"><see cref="HttpMethod"/> to use in performing the request.</param>
        /// <param name="uri"><see cref="Uri"/> to perform the request against.</param>
        /// <param name="body">Payload to send to the server.
        /// If specified as a <see cref="Dictionary{string, string}"/> then <see cref="FormUrlEncodedContent"/> is expected,
        /// otherwise <see cref="StringContent"/> containing the JSON representation of the object is expected.</param>
        /// <param name="headers">Optional <see cref="Dictionary{string, string}"/> containing additional headers that may override the defaults.</param>
        /// <param name="files">Optional <see cref="IList{FileUploadParameter>"/> containing file contents to upload as a <see cref="MultipartFormDataContent"/> post.</param>
        /// <returns><see cref="Task{T}"/> representing the async operation containing response body as <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <paramref name="files"/> can only be specified if <paramref name="body"/> is <see cref="IDictionary{string, object}"/>.
        /// </remarks>
        Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null);
    }
}
