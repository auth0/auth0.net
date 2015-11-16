using System;
using System.Runtime.InteropServices;
using Auth0.Api.Management.Clients;

namespace Auth0.Api.Management
{
    public class ManagementClient : IManagementClient
    {
        private readonly ApiConnection apiConnection;

        public IClientsClient Clients { get; }
        public IConnectionsClient Connections { get; }
        public IDeviceCredentialsClient DeviceCredentials { get; }
        public IEmailsClient Emails { get; }
        public IJobsClient Jobs { get; }
        public IRulesClient Rules { get; }
        public ITicketsClient Tickets { get; }
        public IStatsClient Stats { get; }
        public IUsersClient Users { get; }

        public ManagementClient(string token, Uri baseUri)
        {
            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri);

            Clients = new ClientsClient(apiConnection);
            Connections = new ConnectionsClient(apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(apiConnection);
            Emails = new EmailsClient(apiConnection);
            Jobs = new JobsClient(apiConnection);
            Rules = new RulesClient(apiConnection);
            Stats = new StatsClient(apiConnection);
            Tickets = new TicketsClient(apiConnection);
            Users = new UsersClient(apiConnection);
        }
    }
}