using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Interface used to customize implementation or mock behavior of <see cref="AuthenticationApiClient"/>.
    /// </summary>
    public interface IAuthenticationConnection
    {
        /// <summary>
        /// Send a HTTP GET request to the given <paramref name="uri"/> with optional <paramref name="headers"/> as
        /// an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result into.</typeparam>
        /// <param name="uri">Absolute <see cref="Uri"/> to send the request to.</param>
        /// <param name="headers">Optional dictionary containing additional headers to be sent.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send an HTTP request to <paramref name="uri"/> using the HTTP <paramref name="method"/> as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize the result into.</typeparam>
        /// <param name="method"><see cref="HttpMethod"/> to use.</param>
        /// <param name="uri">Absolute <see cref="Uri"/> to send the request to.</param>
        /// <param name="body">Body of the HTTP request that will be sent.</param>
        /// <param name="headers">Optional dictionary containing additional headers to be sent.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default);
    }
}
