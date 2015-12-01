using System.Collections.Generic;
using System.Threading.Tasks;
using PortableRest;
using Auth0.Core.ApiClients;

#if MANAGEMENT_API
using Auth0.ManagementApi.Client.Models;
#elif AUTHENTICATION_API
using Auth0.AuthenticationApi.Client.Models;
#endif

#if MANAGEMENT_API
namespace Auth0.ManagementApi.Client
#elif AUTHENTICATION_API
namespace Auth0.AuthenticationApi.Client
#endif
{
    /// <summary>
    /// The communication layer between the various API clients and the actual API backend. All API calls happen through this interface.
    /// </summary>
    public interface IApiConnection
    {
        Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class;

        Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class;

        Task<T> PostAsync<T>(string resource, ContentTypes contentTypes, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class;

        Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class;
    }
}