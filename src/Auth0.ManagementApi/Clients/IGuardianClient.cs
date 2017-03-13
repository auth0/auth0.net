using System;
using System.Collections.Generic;
using System.Text;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public interface IGuardianClient
    {
        /// <summary>
        /// Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns><see cref="GuardianFactor"/> containing a list of available factors.</returns>
        Task<IList<GuardianFactor>> GetGuardianFactorsAsync();
    }
}
