using System.Threading.Tasks;
using System.Threading;

namespace Auth0.ManagementApi
{
    public interface ICache
    {
        Task<T> GetAsync<T>(string key, CancellationToken token = default) where T : class;
        Task RemoveAsync(string key, CancellationToken token = default);
        Task SetAsync<T>(string key, T value, CancellationToken token = default);
    }
}