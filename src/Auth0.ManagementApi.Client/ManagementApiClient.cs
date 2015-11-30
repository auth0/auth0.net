using System;
using Auth0.ManagementApi.Client.Clients;
using Auth0.ManagementApi.Client.Diagnostics;
using Auth0.Core.ApiClients;

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

        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri, diagnostics);

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
        public ManagementApiClient(string token, Uri baseUri)
            : this(token, baseUri, null)
        {
        }
    }
}