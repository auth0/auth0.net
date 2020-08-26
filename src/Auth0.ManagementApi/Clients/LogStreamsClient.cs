using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /log-streams endpoint
    /// </summary>
    public class LogStreamsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LogStreamsClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public LogStreamsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets all of the log streams
        /// </summary>
        /// <returns>A list of <see cref="LogStream"/> objects</returns>
        public Task<IList<LogStream>> GetAllAsync()
        {
            return Connection.GetAsync<IList<LogStream>>(BuildUri("log-streams"), DefaultHeaders);
        }
    }
}

