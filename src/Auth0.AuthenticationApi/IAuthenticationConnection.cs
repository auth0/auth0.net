using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    public interface IAuthenticationConnection
    {
        Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null);
        Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null);
    }
}
