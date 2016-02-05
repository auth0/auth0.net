using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Auth0.Core.Http
{
    /// <summary>
    /// The communication layer between the various API clients and the actual API back-end. All API calls happen through this interface.
    /// </summary>
    public interface IApiConnection
    {
        /// <summary>
        /// Performs an HTTP DELETE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class;

        /// <summary>
        /// Performs an HTTP GET.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="converters">The list of <see cref="JsonConverter"/> to use during deserialization.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers, params JsonConverter[] converters) where T : class;

        /// <summary>
        /// Performs an HTTP POST.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="fileParameters">The file parameters.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class;

        /// <summary>
        /// Performs an HTTP PATCH.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class;
    }
}