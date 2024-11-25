using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.SelfServiceProfiles;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class SelfServiceProfileTestFixture : TestBaseFixture
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

public class SelfServiceProfileTest : IClassFixture<SelfServiceProfileTestFixture>
{
    private SelfServiceProfileTestFixture _fixture;

    public SelfServiceProfileTest(SelfServiceProfileTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Test_self_service_profile_crud_operation()
    {
        // Create a self-service provider
        var createRequest = GetASelfServiceProfileCreateRequest();
        var ssp = await _fixture.ApiClient.SelfServiceProfilesClient.CreateAsync(createRequest);
        _fixture.TrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
        ssp.Should().BeEquivalentTo(createRequest);

        // Get the created self-service provider
        var sspAfterCreation = await _fixture.ApiClient.SelfServiceProfilesClient.GetAsync(ssp.Id);
        sspAfterCreation.Should().BeEquivalentTo(createRequest);

        // update the self-service provider
        var sspUpdateRequest = GetASelfServiceProfileUpdateRequest();
        var sspUpdated = await _fixture.ApiClient.SelfServiceProfilesClient.UpdateAsync(ssp.Id, sspUpdateRequest);
        sspUpdated.Should().BeEquivalentTo(sspUpdateRequest);

        // Get All self-service providers
        var allSsps = await _fixture.ApiClient.SelfServiceProfilesClient.GetAllAsync();
        allSsps.Count.Should().BeGreaterOrEqualTo(1);

        // Delete the self-service provider
        await _fixture.ApiClient.SelfServiceProfilesClient.DeleteAsync(ssp.Id);
    }

    [Fact]
    public async void Test_self_service_sso_ticket_generation_revocation()
    {
        var createRequest = GetASelfServiceProfileCreateRequest();
        var ssp = await CreateASelfServiceProfile(createRequest);

        var existingOrganizationId = "org_V6ojENVd1ERs5YY1";
        var ssoTicket = await _fixture.ApiClient.SelfServiceProfilesClient.CreateSsoTicketAsync(
            ssp.Id, new SelfServiceSsoTicketCreateRequest()
            {
                ConnectionConfig = new SelfServiceSsoConnectionConfig()
                {
                    Name = "Test-Connection-For-SSO"
                },
                EnabledOrganizations = new List<EnabledOrganization>()
                {
                    new EnabledOrganization()
                    {
                        OrganizationId = existingOrganizationId
                    }
                }
            });

        ssoTicket.Should().NotBeNull();

        // Revoke the SSO ticket
        await _fixture.ApiClient.SelfServiceProfilesClient.RevokeSsoTicketAsync(ssp.Id, ssoTicket.Ticket.Split('=').Last());

        // Delete the self-service profile
        await _fixture.ApiClient.SelfServiceProfilesClient.DeleteAsync(ssp.Id);
    }

    [Fact]
    public async void Test_self_service_custom_text_get_set()
    {
        var ssp = await CreateASelfServiceProfile();

        var customTextBody = new Dictionary<string, string>()
        {
            { "introduction", "Hello this is welcome page" }
        };

        var customText =
            await _fixture.ApiClient.SelfServiceProfilesClient.SetCustomTextForSelfServiceProfileAsync(
                ssp.Id, "en", "get-started", customTextBody);

        customText.Should().NotBeNull();
        customTextBody.Should()
            .BeEquivalentTo(JsonConvert.DeserializeObject<Dictionary<string, string>>(customText.ToString()));

        // Fetch the custom text and validate
        var getCustomText =
            await _fixture.ApiClient.SelfServiceProfilesClient.GetCustomTextForSelfServiceProfileAsync(
                ssp.Id, "en", "get-started");
        getCustomText.Should().BeEquivalentTo(customText);

        // Delete the self-service profile
        await _fixture.ApiClient.SelfServiceProfilesClient.DeleteAsync(ssp.Id);
    }


    private SelfServiceProfileCreateRequest GetASelfServiceProfileCreateRequest()
    {
        var createRequest = new SelfServiceProfileCreateRequest()
        {
            Name = "Test Self Service Profile",
            Description = "Test Self Service Profile Description",
            UserAttributes = new List<UserAttribute>()
            {
                new UserAttribute()
                {
                    Name = "email",
                    Description = "Email",
                    IsOptional = false
                }
            },
            Branding = new Branding()
            {
                LogoUrl = "https://example.com/logo.png",
                Color = new Color()
                {
                    Primary = "#FF0000"
                }
            },
            AllowedStrategies = new string[] { "oidc" }
        };
        return createRequest;
    }

    private SelfServiceProfileUpdateRequest GetASelfServiceProfileUpdateRequest()
    {
        var sspUpdateRequest = new SelfServiceProfileUpdateRequest()
        {
            Name = "Test Self Service Profile Updated",
            Description = "Test Self Service Profile Description Updated",
            UserAttributes = new List<UserAttribute>()
            {
                new UserAttribute()
                {
                    Name = "email",
                    Description = "Email",
                    IsOptional = true
                }
            },
            Branding = new Branding()
            {
                LogoUrl = "https://example.com/logo-updated.png",
                Color = new Color()
                {
                    Primary = "#00FF00"
                }
            },
            AllowedStrategies = new string[] { "samlp" }
        };
        return sspUpdateRequest;
    }

    private async Task<SelfServiceProfile> CreateASelfServiceProfile(
        SelfServiceProfileCreateRequest createRequest = null)
    {
        createRequest ??= GetASelfServiceProfileCreateRequest();

        // Given a self-service profile
        var ssp = await _fixture.ApiClient.SelfServiceProfilesClient.CreateAsync(createRequest);
        _fixture.TrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
        ssp.Should().BeEquivalentTo(createRequest);
        return ssp;
    }
}