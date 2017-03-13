using Auth0.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class GuardianTests : TestBase, IAsyncLifetime
    {
        IManagementApiClient _managementApiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _managementApiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Can_retrieve_guardian_factors()
        {
            var response = await _managementApiClient.Guardian.GetGuardianFactorsAsync();

            response.Should().HaveCount(2);
        }
    }
}
