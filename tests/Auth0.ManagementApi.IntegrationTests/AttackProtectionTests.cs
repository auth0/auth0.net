using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.AttackProtection;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class AttackProtectionTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class AttackProtectionTests : IClassFixture<AttackProtectionTestsFixture>
    {
        AttackProtectionTestsFixture fixture;

        public AttackProtectionTests(AttackProtectionTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_suspicious_ip_throttling_crud_sequence()
        {
            var before = await fixture.ApiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();

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

                var updated = await fixture.ApiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(toUpdate);

                var after = await fixture.ApiClient.AttackProtection.GetSuspiciousIpThrottlingAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await fixture.ApiClient.AttackProtection.UpdateSuspiciousIpThrottlingAsync(before);
            }
        }

        [Fact]
        public async Task Test_breached_password_detection_crud_sequence()
        {
            var before = await fixture.ApiClient.AttackProtection.GetBreachedPasswordDetectionAsync();

            try
            {
                var toUpdate = new BreachedPasswordDetection
                {
                    Shields = new[] { "admin_notification" },
                    AdminNotificationFrequency = new[] { "daily" },
                    Method = "standard",
                    Enabled = true,
                    Stage = new BreachedPasswordDetectionStage
                    {
                        PreUserRegistration = new BreachedPasswordDetectionStage.StageEntry
                        {
                            Shields = new[] { "admin_notification" }
                        }
                    }
                };

                var updated = await fixture.ApiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(toUpdate);

                var after = await fixture.ApiClient.AttackProtection.GetBreachedPasswordDetectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await fixture.ApiClient.AttackProtection.UpdateBreachedPasswordDetectionAsync(before);
            }
        }

        [Fact]
        public async Task Test_brute_force_protection_crud_sequence()
        {
            var before = await fixture.ApiClient.AttackProtection.GetBruteForceProtectionAsync();

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

                var updated = await fixture.ApiClient.AttackProtection.UpdateBruteForceProtectionAsync(toUpdate);

                var after = await fixture.ApiClient.AttackProtection.GetBruteForceProtectionAsync();


                updated.Should().BeEquivalentTo(toUpdate);
                after.Should().BeEquivalentTo(updated);
            }
            finally
            {
                await fixture.ApiClient.AttackProtection.UpdateBruteForceProtectionAsync(before);
            }
        }
    }
}
