using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.IntegrationTests.Testing;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

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
    private AttackProtectionTestsFixture fixture;

    public AttackProtectionTests(AttackProtectionTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_suspicious_ip_throttling_crud_sequence()
    {
        var before = await fixture.ApiClient.AttackProtection.SuspiciousIpThrottling.GetAsync();

        try
        {
            var toUpdate = new UpdateSuspiciousIpThrottlingSettingsRequestContent
            {
                Allowlist = new[] { "1.1.1.1", "2.2.2.2" },
                Shields = new[] { SuspiciousIpThrottlingShieldsEnum.Block },
                Enabled = true,
                Stage = new SuspiciousIpThrottlingStage
                {
                    PreLogin = new SuspiciousIpThrottlingPreLoginStage
                    {
                        MaxAttempts = 12,
                        Rate = 864000
                    },
                    PreUserRegistration = new SuspiciousIpThrottlingPreUserRegistrationStage
                    {
                        MaxAttempts = 12,
                        Rate = 1728000
                    }
                }
            };

            var updated = await fixture.ApiClient.AttackProtection.SuspiciousIpThrottling.UpdateAsync(toUpdate);

            var after = await fixture.ApiClient.AttackProtection.SuspiciousIpThrottling.GetAsync();

            updated.Enabled.Should().Be(toUpdate.Enabled);
            after.Enabled.Should().Be(updated.Enabled);
        }
        finally
        {
            // Restore original settings
            await fixture.ApiClient.AttackProtection.SuspiciousIpThrottling.UpdateAsync(new UpdateSuspiciousIpThrottlingSettingsRequestContent
            {
                Allowlist = before.Allowlist,
                Shields = before.Shields,
                Enabled = before.Enabled,
                Stage = before.Stage
            });
        }
    }

    [Fact]
    public async Task Test_breached_password_detection_crud_sequence()
    {
        var before = await fixture.ApiClient.AttackProtection.BreachedPasswordDetection.GetAsync();

        try
        {
            var toUpdate = new UpdateBreachedPasswordDetectionSettingsRequestContent
            {
                Shields = new[] { BreachedPasswordDetectionShieldsEnum.AdminNotification },
                AdminNotificationFrequency = new[] { BreachedPasswordDetectionAdminNotificationFrequencyEnum.Daily },
                Method = BreachedPasswordDetectionMethodEnum.Standard,
                Enabled = true,
                Stage = new BreachedPasswordDetectionStage
                {
                    PreUserRegistration = new BreachedPasswordDetectionPreUserRegistrationStage
                    {
                        Shields = new[] { BreachedPasswordDetectionPreUserRegistrationShieldsEnum.AdminNotification }
                    }
                }
            };

            var updated = await fixture.ApiClient.AttackProtection.BreachedPasswordDetection.UpdateAsync(toUpdate);

            var after = await fixture.ApiClient.AttackProtection.BreachedPasswordDetection.GetAsync();

            updated.Enabled.Should().Be(toUpdate.Enabled);
            after.Enabled.Should().Be(updated.Enabled);
        }
        finally
        {
            // Restore original settings
            await fixture.ApiClient.AttackProtection.BreachedPasswordDetection.UpdateAsync(new UpdateBreachedPasswordDetectionSettingsRequestContent
            {
                Shields = before.Shields,
                AdminNotificationFrequency = before.AdminNotificationFrequency,
                Method = before.Method,
                Enabled = before.Enabled,
                Stage = before.Stage
            });
        }
    }

    [Fact]
    public async Task Test_brute_force_protection_crud_sequence()
    {
        var before = await fixture.ApiClient.AttackProtection.BruteForceProtection.GetAsync();

        try
        {
            var toUpdate = new UpdateBruteForceSettingsRequestContent
            {
                Enabled = true,
                Shields = new[] { UpdateBruteForceSettingsRequestContentShieldsItem.Block },
                Allowlist = new[] { "1.1.1.1", "2.2.2.2" },
                Mode = UpdateBruteForceSettingsRequestContentMode.CountPerIdentifier,
                MaxAttempts = 11,
            };

            var updated = await fixture.ApiClient.AttackProtection.BruteForceProtection.UpdateAsync(toUpdate);

            var after = await fixture.ApiClient.AttackProtection.BruteForceProtection.GetAsync();

            updated.Enabled.Should().Be(toUpdate.Enabled);
            after.Enabled.Should().Be(updated.Enabled);
        }
        finally
        {
            // Restore original settings
            await fixture.ApiClient.AttackProtection.BruteForceProtection.UpdateAsync(new UpdateBruteForceSettingsRequestContent
            {
                Enabled = before.Enabled,
                Shields = before.Shields?.Select(s => (UpdateBruteForceSettingsRequestContentShieldsItem)(string)s),
                Allowlist = before.Allowlist,
                Mode = before.Mode != null ? (UpdateBruteForceSettingsRequestContentMode?)(string)before.Mode : null,
                MaxAttempts = before.MaxAttempts
            });
        }
    }
}
