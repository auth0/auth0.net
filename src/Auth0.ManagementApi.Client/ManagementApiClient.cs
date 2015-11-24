using System;
using Auth0.ManagementApi.Client.Clients;

namespace Auth0.ManagementApi.Client
{
    public class ManagementApiClient : IManagementApiClient
    {
        private readonly ApiConnection apiConnection;

        public IBlacklistedTokensClient BlacklistedTokens { get; }
        public IClientsClient Clients { get; }
        public IConnectionsClient Connections { get; }
        public IDeviceCredentialsClient DeviceCredentials { get; }
        public IEmailProviderClient EmailProvider { get; }
        public IJobsClient Jobs { get; }
        public IRulesClient Rules { get; }
        public IStatsClient Stats { get; }
        public ITentantSettingsClient TenantSettings { get; set; }
        public ITicketsClient Tickets { get; }
        public IUsersClient Users { get; }

        public ManagementApiClient(string token, Uri baseUri)
        {
            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri);

            BlacklistedTokens = new BlacklistedTokensClient(apiConnection);
            Clients = new ClientsClient(apiConnection);
            Connections = new ConnectionsClient(apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(apiConnection);
            EmailProvider = new EmailProviderClient(apiConnection);
            Jobs = new JobsClient(apiConnection);
            Rules = new RulesClient(apiConnection);
            Stats = new StatsClient(apiConnection);
            TenantSettings = new TentantSettingsClient(apiConnection);
            Tickets = new TicketsClient(apiConnection);
            Users = new UsersClient(apiConnection);
        }
    }
}