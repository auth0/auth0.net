using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        /// <summary>
        /// Gets a log stream
        /// </summary>
        /// <param name="id">The id of the log stream to get</param>
        /// <returns>A <see cref="LogStream"/> object</returns>
        public Task<LogStream> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.GetAsync<LogStream>(BuildUri($"log-streams/{EncodePath(id)}"), DefaultHeaders);
        }

        /// <summary>
        /// Creates a new log stream
        /// </summary>
        /// <param name="request">The <see cref="LogStreamCreateRequest"/> containing the information needed to create the log stream</param>
        /// <returns>A <see cref="Task"/> that represents the  asynchronous create operation.</returns>
        public Task<LogStream> CreateAsync(LogStreamCreateRequest request)
        {
            return Connection.SendAsync<LogStream>(HttpMethod.Post, BuildUri("log-streams"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes a log stream
        /// </summary>
        /// <param name="id">The id of the log stream to delete</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"log-streams/{EncodePath(id)}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Updates a log stream
        /// </summary>
        /// <param name="id">The id of the log stream to update</param>
        /// <param name="request">The information required to update the log stream</param>
        /// <returns>The updated <see cref="LogStream"/> object</returns>
        public Task<LogStream> UpdateAsync(string id, LogStreamUpdateRequest request)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.SendAsync<LogStream>(new HttpMethod("PATCH"), BuildUri($"log-streams/{EncodePath(id)}"), request, DefaultHeaders);
        }
    }
}

