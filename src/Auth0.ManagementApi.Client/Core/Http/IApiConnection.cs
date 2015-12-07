using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Auth0.Core.Http
{
    /// <summary>
    /// The communication layer between the various API clients and the actual API backend. All API calls happen through this interface.
    /// </summary>
    public interface IApiConnection
    {
        Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class;

        Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers) where T : class;

        Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class;

        Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class;
    }
}