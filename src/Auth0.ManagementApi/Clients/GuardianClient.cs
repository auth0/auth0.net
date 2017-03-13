using System;
using System.Collections.Generic;
using System.Text;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public class GuardianClient : ClientBase, IGuardianClient
    {
        public GuardianClient(IApiConnection connection) : base(connection)
        {
        }

        public Task<IList<GuardianFactor>> GetGuardianFactorsAsync()
        {
            return Connection.GetAsync<IList<GuardianFactor>>("guardian/factors", null, null, null, null);
        }
    }
}
