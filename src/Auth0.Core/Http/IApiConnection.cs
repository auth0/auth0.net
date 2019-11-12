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

        Task<T> RequestAsync<T>(HttpMethod httpMethod,
            string path,
            object body = null,
            IDictionary<string, object> parameters = null,
            IList<FileUploadParameter> fileParameters = null,
            IDictionary<string, object> headers = null,
            IDictionary<string, string> queryStrings = null,
            params JsonConverter[] converters) where T : class;
    }
}
