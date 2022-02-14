using System.Threading.Tasks;
using Auth0.ManagementApi.Models.AttackProtection;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class AttackProtectionTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public Task DisposeAsync()
        {
            _apiClient.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Test_suspicious_ip_throttling_crud_sequence()
        {
            var before = await _apiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();

            try
            {
                var toUpdate = new SuspiciousIpThrottling
                {
                    Allowlist = new[] { "1.1.1.1", "2.2.2.2" },
                    Shields = new[] { "block" },
                    Enabled = true,
                    Stage = new Stage
                    {
                        PreLogin = new Stage.StageEntry
                        {
                            MaxAttempts = 12,
                            Rate = 864000
                        },
                        PreUserRegistration = new Stage.StageEntry
                        {
                            MaxAttempts = 12,
                            Rate = 1728000
                        }
                    }
                };

                var updated = await _apiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(toUpdate);

                var after = await _apiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await _apiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(before);
            }
        }

        [Fact]
        public async Task Test_breached_password_detection_crud_sequence()
        {
            var before = await _apiClient.AttackProtection.GetBreachedPasswordDetectionAsync();

            try
            {
                var toUpdate = new BreachedPasswordDetection
                {
                    Shields = new[] { "admin_notification" },
                    AdminNotificationFrequency = new[] { "daily" },
                    Method = "enhanced",
                    Enabled = true,
                };

                var updated = await _apiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(toUpdate);

                var after = await _apiClient.AttackProtection.GetBreachedPasswordDetectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await _apiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(before);
            }
        }

        [Fact]
        public async Task Test_brute_force_protection_crud_sequence()
        {
            var before = await _apiClient.AttackProtection.GetBruteForceProtectionAsync();

            try
            {
                var toUpdate = new BruteForceProtection
                {
                    Enabled = true,
                    Shields = new[] { "block" },
                    Allowlist = new[] { "1.1.1.1", "2.2.2.2" },
                    Mode = "count_per_identifier",
                    MaxAttempts = 11,
                };

                var updated = await _apiClient.AttackProtection.UpdateBruteForceProtectionAsync(toUpdate);

                var after = await _apiClient.AttackProtection.GetBruteForceProtectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await _apiClient.AttackProtection.UpdateBruteForceProtectionAsync(before);
            }
        }
    }
}
