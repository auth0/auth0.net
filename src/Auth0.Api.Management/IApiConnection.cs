using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PortableRest;

namespace Auth0.Api.Management
{
    public interface IApiConnection
    {
        Task<T> GetAsync<T>(string resource, IDictionary<string, string> parameters, string accepts) where T : class;
    }
}