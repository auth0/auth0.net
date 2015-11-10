using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public interface IClientsClient
    {
        /// <summary>
        /// Retrieves a list of all client applications.
        /// </summary>
        /// <returns>
        /// </returns>
        Task<IList<Client>> GetAll(string fields = null, bool includeFields = true);
    }
}