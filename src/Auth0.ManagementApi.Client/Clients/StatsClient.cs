using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;

namespace Auth0.ManagementApi.Client.Clients
{
    public class StatsClient :  ClientBase, IStatsClient
    {
        public StatsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public async Task<long> GetActiveUsers()
        {
            var result = await Connection.GetAsync<object>("stats/active-users", null, null, null);

            return Convert.ToInt64(result);
        }

        public Task<IList<DailyStatistics>> GetDailyStats(DateTime from, DateTime to)
        {
            return Connection.GetAsync<IList<DailyStatistics>>("stats/daily", null, 
                new Dictionary<string, string>
                {
                    { "from", from.ToString("yyyyMMdd") },
                    { "to", to.ToString("yyyyMMdd") }
                }, null);
        }
    }
}