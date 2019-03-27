using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /stats endpoints.
    /// </summary>
    public class StatsClient : ClientBase, IStatsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="StatsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public StatsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<long> GetActiveUsersAsync()
        {
            var result = await Connection.GetAsync<object>("stats/active-users", null, null, null, null).ConfigureAwait(false);

            return Convert.ToInt64(result);
        }

        /// <inheritdoc />
        public Task<IList<DailyStatistics>> GetDailyStatsAsync(DateTime from, DateTime to)
        {
            return Connection.GetAsync<IList<DailyStatistics>>("stats/daily", null,
                new Dictionary<string, string>
                {
                    { "from", from.ToString("yyyyMMdd") },
                    { "to", to.ToString("yyyyMMdd") }
                }, null, null);
        }
    }
}