using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests;

public class DeviceCredentialsTests : TestBase
{
    // Device credentials tests are limited due to authentication requirements.
    // The management API v2 token cannot create device credentials.
    // The remaining mock-based test has been removed as it relied on the old API structure.
}
