using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.SelfServiceProfiles;
using FluentAssertions;
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
        var ssp = await _fixture.ApiClient.SelfServiceProfiles.CreateAsync(createRequest);
        _fixture.TrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
        ssp.Should().NotBeNull();
        ssp.Name.Should().Be(createRequest.Name);

        // Get the created self-service provider
        var sspAfterCreation = await _fixture.ApiClient.SelfServiceProfiles.GetAsync(ssp.Id);
        sspAfterCreation.Name.Should().Be(createRequest.Name);

        // update the self-service provider
        var sspUpdateRequest = GetASelfServiceProfileUpdateRequest();
        var sspUpdated = await _fixture.ApiClient.SelfServiceProfiles.UpdateAsync(ssp.Id, sspUpdateRequest);
        sspUpdated.Name.Should().Be(sspUpdateRequest.Name);

        // Get All self-service providers
        var allSspsPager = await _fixture.ApiClient.SelfServiceProfiles.ListAsync(new ListSelfServiceProfilesRequestParameters());
        var allSsps = allSspsPager.CurrentPage.Items.ToList();
        allSsps.Count.Should().BeGreaterOrEqualTo(1);

        // Delete the self-service provider
        await _fixture.ApiClient.SelfServiceProfiles.DeleteAsync(ssp.Id);
        _fixture.UnTrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
    }

    [Fact]
    public async void Test_self_service_sso_ticket_generation_revocation()
    {
        var createRequest = GetASelfServiceProfileCreateRequest();
        var ssp = await CreateASelfServiceProfile(createRequest);

        var existingOrganizationId = "org_x2j4mAL75v96wKkt";
        var ssoTicket = await _fixture.ApiClient.SelfServiceProfiles.SsoTicket.CreateAsync(
            ssp.Id, new CreateSelfServiceProfileSsoTicketRequestContent
            {
                ConnectionConfig = new SelfServiceProfileSsoTicketConnectionConfig
                {
                    Name = "Test-Connection-For-SSO",
                    DisplayName = "Test Display Name",
                    IsDomainConnection = false,
                    Metadata = new Dictionary<string, string?>(),
                    ShowAsButton = false,
                    Options = new SelfServiceProfileSsoTicketConnectionOptions
                    {
                        DomainAliases = new[] { "alias1", "alias2" },
                        IconUrl = "https://cdn2.auth0.com/styleguide/latest/lib/logos/img/favicon.png",
                        Idpinitiated = new SelfServiceProfileSsoTicketIdpInitiatedOptions
                        {
                            Enabled = true,
                            ClientId = "AydyL76hVpC0meG2T7lTTQn667mrzS3A",
                            ClientAuthorizequery = "redirect_uri",
                            ClientProtocol = SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum.Oauth2
                        }
                    }
                },
                EnabledOrganizations = new List<SelfServiceProfileSsoTicketEnabledOrganization>
                {
                    new()
                    {
                        OrganizationId = existingOrganizationId,
                        AssignMembershipOnLogin = false,
                        ShowAsButton = false
                    }
                },
                TtlSec = 10000,
                DomainAliasesConfig = new SelfServiceProfileSsoTicketDomainAliasesConfig
                {
                    DomainVerification = SelfServiceProfileSsoTicketDomainVerificationEnum.Optional
                }
            });

        ssoTicket.Should().NotBeNull();

        // Revoke the SSO ticket
        await _fixture.ApiClient.SelfServiceProfiles.SsoTicket.RevokeAsync(ssp.Id, ssoTicket.Ticket.Split('=').Last());

        // Delete the self-service profile
        await _fixture.ApiClient.SelfServiceProfiles.DeleteAsync(ssp.Id);
        _fixture.UnTrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
    }

    [Fact]
    public async void Test_self_service_custom_text_get_set()
    {
        var ssp = await CreateASelfServiceProfile();

        var customTextBody = new Dictionary<string, string>
        {
            { "introduction", "Hello this is welcome page" }
        };

        var customText =
            await _fixture.ApiClient.SelfServiceProfiles.CustomText.SetAsync(
                ssp.Id, SelfServiceProfileCustomTextLanguageEnum.En, SelfServiceProfileCustomTextPageEnum.GetStarted, customTextBody);

        customText.Should().NotBeNull();

        // Fetch the custom text and validate
        var getCustomText =
            await _fixture.ApiClient.SelfServiceProfiles.CustomText.ListAsync(
                ssp.Id, SelfServiceProfileCustomTextLanguageEnum.En, SelfServiceProfileCustomTextPageEnum.GetStarted);
        getCustomText.Should().NotBeNull();

        // Delete the self-service profile
        await _fixture.ApiClient.SelfServiceProfiles.DeleteAsync(ssp.Id);
        _fixture.UnTrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
    }


    private CreateSelfServiceProfileRequestContent GetASelfServiceProfileCreateRequest()
    {
        var createRequest = new CreateSelfServiceProfileRequestContent
        {
            Name = "Test Self Service Profile",
            Description = "Test Self Service Profile Description",
            UserAttributes = new List<SelfServiceProfileUserAttribute>
            {
                new()
                {
                    Name = "email",
                    Description = "Email",
                    IsOptional = false
                }
            },
            Branding = new SelfServiceProfileBrandingProperties
            {
                LogoUrl = "https://example.com/logo.png",
                Colors = new SelfServiceProfileBrandingColors
                {
                    Primary = "#FF0000"
                }
            },
            AllowedStrategies = new[] { SelfServiceProfileAllowedStrategyEnum.Oidc }
        };
        return createRequest;
    }

    private UpdateSelfServiceProfileRequestContent GetASelfServiceProfileUpdateRequest()
    {
        var sspUpdateRequest = new UpdateSelfServiceProfileRequestContent
        {
            Name = "Test Self Service Profile Updated",
            Description = "Test Self Service Profile Description Updated",
            UserAttributes = new List<SelfServiceProfileUserAttribute>
            {
                new()
                {
                    Name = "email",
                    Description = "Email",
                    IsOptional = true
                }
            },
            Branding = new SelfServiceProfileBrandingProperties
            {
                LogoUrl = "https://example.com/logo-updated.png",
                Colors = new SelfServiceProfileBrandingColors
                {
                    Primary = "#00FF00"
                }
            },
            AllowedStrategies = new[] { SelfServiceProfileAllowedStrategyEnum.Samlp }
        };
        return sspUpdateRequest;
    }

    private async Task<CreateSelfServiceProfileResponseContent> CreateASelfServiceProfile(
        CreateSelfServiceProfileRequestContent createRequest = null)
    {
        createRequest ??= GetASelfServiceProfileCreateRequest();

        // Given a self-service profile
        var ssp = await _fixture.ApiClient.SelfServiceProfiles.CreateAsync(createRequest);
        _fixture.TrackIdentifier(CleanUpType.SelfServiceProvider, ssp.Id);
        ssp.Should().NotBeNull();
        ssp.Name.Should().Be(createRequest.Name);
        return ssp;
    }
}
