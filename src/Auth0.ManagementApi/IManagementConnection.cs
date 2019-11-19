using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    public interface IManagementConnection
    {
        Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null);
        Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null);
    }
}
