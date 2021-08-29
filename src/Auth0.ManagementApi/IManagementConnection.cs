using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
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
        /// Perform a HTTP GET operation against a given <see cref="Uri"/> and return the materialized response body as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result content as.</typeparam>
        /// <param name="uri"><see cref="Uri"/> to perform the GET request against.</param>
        /// <param name="headers">Dictionary containing additional headers that may override the defaults.</param>
        /// <param name="converters">Optional array of <see cref="JsonConverter"/>s used to deserialize the resulting <typeparamref name="T"/>.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns><see cref="Task"/> representing the async operation containing response body as <typeparamref name="T"/>.</returns>
        Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers, JsonConverter[] converters = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Perform a HTTP operation against a given <see cref="Uri"/> and return any materialized response body as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result content as.</typeparam>
        /// <param name="method"><see cref="HttpMethod"/> to use in performing the request.</param>
        /// <param name="uri"><see cref="Uri"/> to perform the request against.</param>
        /// <param name="body">Payload to send to the server.
        /// If specified as a Dictionary&lt;string, string&gt; then <see cref="FormUrlEncodedContent"/> is expected,
        /// otherwise <see cref="StringContent"/> containing the JSON representation of the object is expected.</param>
        /// <param name="headers">Dictionary containing additional headers that may override the defaults.</param>
        /// <param name="files">Optional <see cref="IList{FileUploadParameter>"/> containing file contents to upload as a <see cref="MultipartFormDataContent"/> post.</param>
        /// <param name="converters">Optional array of <see cref="JsonConverter"/>s used to deserialize the resulting <typeparamref name="T"/>.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns><see cref="Task"/> representing the async operation containing response body as <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <paramref name="files"/> can only be specified if <paramref name="body"/> is a Dictionary%lt;string, object%gt;"/>.
        /// </remarks>
        Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers, IList<FileUploadParameter> files = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default);
    }
}
