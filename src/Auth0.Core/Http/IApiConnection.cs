using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.Core.Http
{
    /// <summary>
    /// The communication layer between the various API clients and the actual API back-end. All API calls happen through
    /// this interface.
    /// </summary>
    public interface IApiConnection
    {
        /// <summary>
        /// Contains information about the last API call made by the connection.
        /// </summary>
        ApiInfo ApiInfo { get; }

        /// <summary>
        /// Performs an HTTP DELETE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings"></param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments = null,
            IDictionary<string, string> queryStrings = null) where T : class;

        /// <summary>
        ///     Performs an HTTP DELETE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">The body.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings"></param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> DeleteAsync<T>(string resource,
            object body,
            IDictionary<string, string> urlSegments = null,
            IDictionary<string, string> queryStrings = null) where T : class;

        /// <summary>
        /// Performs an HTTP GET.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="converters">The list of <see cref="JsonConverter" /> to use during deserialization.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments = null,
            IDictionary<string, string> queryStrings = null, IDictionary<string, object> headers = null,
            params JsonConverter[] converters) where T : class;

        /// <summary>
        /// Performs an HTTP PATCH.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments = null) where T : class;

        Task<T> RunAsync<T>(HttpMethod httpMethod,
            string resource,
            object body = null,
            IDictionary<string, object> parameters = null,
            IList<FileUploadParameter> fileParameters = null,
            IDictionary<string, string> urlSegments = null,
            IDictionary<string, object> headers = null,
            IDictionary<string, string> queryStrings = null,
            params JsonConverter[] converters) where T : class;
    }
}
