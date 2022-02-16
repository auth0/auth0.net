using System.Threading.Tasks;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.AttackProtection;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class AttackProtectionTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        [Fact]
        public async Task Test_suspicious_ip_throttling_crud_sequence()
        {
            var before = await ApiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();

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

                var updated = await ApiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(toUpdate);

                var after = await ApiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await ApiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(before);
            }
        }

        [Fact]
        public async Task Test_breached_password_detection_crud_sequence()
        {
            var before = await ApiClient.AttackProtection.GetBreachedPasswordDetectionAsync();

            try
            {
                var toUpdate = new BreachedPasswordDetection
                {
                    Shields = new[] { "admin_notification" },
                    AdminNotificationFrequency = new[] { "daily" },
                    Method = "enhanced",
                    Enabled = true,
                };

                var updated = await ApiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(toUpdate);

                var after = await ApiClient.AttackProtection.GetBreachedPasswordDetectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await ApiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(before);
            }
        }

        [Fact]
        public async Task Test_brute_force_protection_crud_sequence()
        {
            var before = await ApiClient.AttackProtection.GetBruteForceProtectionAsync();

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

                var updated = await ApiClient.AttackProtection.UpdateBruteForceProtectionAsync(toUpdate);

                var after = await ApiClient.AttackProtection.GetBruteForceProtectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await ApiClient.AttackProtection.UpdateBruteForceProtectionAsync(before);
            }
        }
    }
}
