using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.Tests.Shared;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ClientTestsFixture : TestBaseFixture
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

public class ClientTests : IClassFixture<ClientTestsFixture>
{
    private ClientTestsFixture fixture;

    public ClientTests(ClientTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_client_crud_sequence()
    {
        string existingOrganizationId = "org_x2j4mAL75v96wKkt";
        var selectedInitiators = new[]
        {
            LogoutInitiators.RpLogout,
            LogoutInitiators.IdpLogout,
            LogoutInitiators.PasswordChanged,
            LogoutInitiators.SessionRevoked,
            LogoutInitiators.AccountDeleted,
            LogoutInitiators.EmailIdentifierChanged
        };

        // Add a new client
        var newClientRequest = new ClientCreateRequest
        {
            Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
            IsFirstParty = true,
            ClientMetaData = new
            {
                Prop1 = "1",
                Prop2 = "2"
            },
            InitiateLoginUri = "https://create.com/login",
            RefreshToken = new RefreshToken
            {
                ExpirationType = RefreshTokenExpirationType.NonExpiring,
                RotationType = RefreshTokenRotationType.NonRotating
            },
            OidcConformant = true,
            GrantTypes = new[] { "refresh_token" },
            OrganizationUsage = OrganizationUsage.Require,
            OrganizationRequireBehavior = OrganizationRequireBehavior.PreLoginPrompt,
            OidcLogout = new OidcLogoutConfig
            {
                BackchannelLogoutInitiators = new BackchannelLogoutInitiators
                {
                    Mode = LogoutInitiatorModes.Custom,
                    SelectedInitiators = selectedInitiators
                },
                BackchannelLogoutUrls = new[] { "https://create.com/logout" }
            },
            DefaultOrganization = new DefaultOrganization()
            {
                OrganizationId = existingOrganizationId,
                Flows = new[] { Flows.ClientCredentials }
            },
            RequirePushedAuthorizationRequests = true,
            SignedRequestObject = new CreateSignedRequestObject()
            {
                Required = true,
                Credentials = new List<CredentialsCreateRequest>()
                {
                    new()
                    {
                        Name = "Sample-Credentials",
                        Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048)),
                        CredentialType = "public_key",
                        Algorithm = "RS256"
                    }
                }
            },
            ComplianceLevel = ComplianceLevel.FAPI1_ADV_PKJ_PAR,
            RequireProofOfPossession = true,
            TokenQuota = new TokenQuota()
            {
                ClientCredentials = new Quota()
                {
                    PerDay = 100,
                    PerHour = 10,
                    Enforce = true
                }
            },
            SessionTransfer = new SessionTransfer()
            {
                AllowedAuthenticationMethods = ["cookie"],
                AllowRefreshToken = true,
                CanCreateSessionTransferToken = true,
                EnforceCascadeRevocation = true,
                EnforceDeviceBinding = DeviceBindingType.Ip,
                EnforceOnlineRefreshTokens = true
            }
        };
        var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);
        fixture.TrackIdentifier(CleanUpType.Clients, newClientResponse.ClientId);
        newClientResponse.Should().NotBeNull();
        newClientResponse.Name.Should().Be(newClientRequest.Name);
        newClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
        newClientResponse.ApplicationType.Should().Be(ClientApplicationType.Native);
        newClientResponse.IsFirstParty.Should().BeTrue();
        newClientResponse.RefreshToken.Should().NotBeNull();
        newClientResponse.RefreshToken.ExpirationType.Should().Be(newClientRequest.RefreshToken.ExpirationType);
        newClientResponse.RefreshToken.RotationType.Should().Be(newClientRequest.RefreshToken.RotationType);
        newClientResponse.OrganizationUsage.Should().Be(OrganizationUsage.Require);
        newClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.PreLoginPrompt);
        newClientResponse.OidcLogout.BackchannelLogoutUrls[0].Should().Be("https://create.com/logout");
        newClientResponse.OidcLogout.BackchannelLogoutInitiators.Mode.Should().Be(LogoutInitiatorModes.Custom);
        newClientResponse.OidcLogout.BackchannelLogoutInitiators.SelectedInitiators.Should()
            .BeEquivalentTo(selectedInitiators);
        newClientResponse.DefaultOrganization.OrganizationId.Should().Be(existingOrganizationId);
        newClientResponse.RequirePushedAuthorizationRequests.Should().BeTrue();
        newClientResponse.SignedRequestObject.Should().NotBeNull();
        newClientResponse.SignedRequestObject.Credentials.Should().NotBeNull();
        newClientResponse.SignedRequestObject.Credentials.First().Id.Should().NotBeNull();
        newClientResponse.ComplianceLevel.Should().Be(ComplianceLevel.FAPI1_ADV_PKJ_PAR);
        newClientResponse.RequireProofOfPossession.Should().BeTrue();
        newClientResponse.TokenQuota.Should().BeEquivalentTo(newClientRequest.TokenQuota);
        
        // Session transfer assertions
        newClientResponse.SessionTransfer.Should().NotBeNull();
        newClientResponse.SessionTransfer?.AllowRefreshToken.Should().BeTrue();
        newClientResponse.SessionTransfer?.EnforceCascadeRevocation.Should().BeTrue();
        newClientResponse.SessionTransfer?.EnforceOnlineRefreshTokens.Should().BeTrue();
        newClientResponse.SessionTransfer?.CanCreateSessionTransferToken.Should().BeTrue();
        newClientResponse.SessionTransfer?.AllowedAuthenticationMethods.Should().BeEquivalentTo(["cookie"]);
        newClientResponse.SessionTransfer?.EnforceDeviceBinding.Should().Be(DeviceBindingType.Ip);

        string prop1 = newClientResponse.ClientMetaData.Prop1;
        prop1.Should().Be("1");
        string prop2 = newClientResponse.ClientMetaData.Prop2;
        prop2.Should().Be("2");
        newClientResponse.GrantTypes.Should().HaveCount(1);
        newClientResponse.InitiateLoginUri.Should().Be("https://create.com/login");

        // Update the client
        var updateClientRequest = new ClientUpdateRequest
        {
            Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
            ApplicationType = ClientApplicationType.Spa,
            GrantTypes = new[] { "refresh_token", "authorization_code" },
            InitiateLoginUri = "https://update.com/login",
            RefreshToken = new RefreshToken
            {
                ExpirationType = RefreshTokenExpirationType.Expiring,
                RotationType = RefreshTokenRotationType.Rotating,
                TokenLifetime = 3600,
                Leeway = 1800
            },
            OrganizationRequireBehavior = OrganizationRequireBehavior.NoPrompt,
            RequirePushedAuthorizationRequests = false,
            SignedRequestObject = new SignedRequestObject()
            {
                Required = false
            },
            ComplianceLevel = ComplianceLevel.NONE,
            RequireProofOfPossession = false,
            TokenQuota = new TokenQuota()
            {
                ClientCredentials = new Quota()
                {
                    Enforce = false
                }
            },
            SessionTransfer = new SessionTransfer()
            {
                AllowedAuthenticationMethods = ["query"],
                AllowRefreshToken = false,
                CanCreateSessionTransferToken = false,
                EnforceCascadeRevocation = false,
                EnforceDeviceBinding = DeviceBindingType.None,
                EnforceOnlineRefreshTokens = false
            }
        };

        var updateClientResponse =
            await fixture.ApiClient.Clients.UpdateAsync(newClientResponse.ClientId, updateClientRequest);
        updateClientResponse.Should().NotBeNull();
        updateClientResponse.Name.Should().Be(updateClientRequest.Name);
        updateClientResponse.TokenEndpointAuthMethod.Should().Be(TokenEndpointAuthMethod.ClientSecretPost);
        updateClientResponse.ApplicationType.Should().Be(ClientApplicationType.Spa);
        updateClientResponse.GrantTypes.Should().HaveCount(2);
        updateClientResponse.InitiateLoginUri.Should().Be("https://update.com/login");
        updateClientResponse.RefreshToken.Should().NotBeNull();
        updateClientResponse.RefreshToken.RotationType.Should().Be(updateClientRequest.RefreshToken.RotationType);
        updateClientResponse.RefreshToken.ExpirationType.Should().Be(updateClientRequest.RefreshToken.ExpirationType);
        updateClientResponse.RefreshToken.TokenLifetime.Should().Be(updateClientRequest.RefreshToken.TokenLifetime);
        updateClientResponse.RefreshToken.Leeway.Should().Be(updateClientRequest.RefreshToken.Leeway);
        updateClientResponse.OrganizationRequireBehavior.Should().Be(OrganizationRequireBehavior.NoPrompt);
        updateClientResponse.OidcLogout.BackchannelLogoutUrls[0].Should().Be("https://create.com/logout");
        updateClientResponse.OidcLogout.BackchannelLogoutInitiators.Mode.Should().Be(LogoutInitiatorModes.Custom);
        updateClientResponse.OidcLogout.BackchannelLogoutInitiators.SelectedInitiators.Should()
            .BeEquivalentTo(selectedInitiators);
        updateClientResponse.DefaultOrganization.OrganizationId.Should().Be(existingOrganizationId);
        updateClientResponse.DefaultOrganization.Flows.Should().HaveCount(1);
        updateClientResponse.DefaultOrganization.Flows.First().Should().Be(Flows.ClientCredentials);
        updateClientResponse.RequirePushedAuthorizationRequests.Should().BeFalse();
        updateClientResponse.SignedRequestObject.Required.Should().BeFalse();
        updateClientResponse.ComplianceLevel.Should().Be(ComplianceLevel.NONE);
        updateClientResponse.RequireProofOfPossession.Should().BeFalse();
        updateClientResponse.TokenQuota.Should().BeEquivalentTo(updateClientRequest.TokenQuota);
        // Session transfer assertions
        updateClientResponse.SessionTransfer.Should().NotBeNull();
        updateClientResponse.SessionTransfer?.AllowRefreshToken.Should().BeFalse();
        updateClientResponse.SessionTransfer?.EnforceCascadeRevocation.Should().BeFalse();
        updateClientResponse.SessionTransfer?.EnforceOnlineRefreshTokens.Should().BeFalse();
        updateClientResponse.SessionTransfer?.CanCreateSessionTransferToken.Should().BeFalse();
        updateClientResponse.SessionTransfer?.AllowedAuthenticationMethods.Should().BeEquivalentTo(["query"]);
        updateClientResponse.SessionTransfer?.EnforceDeviceBinding.Should().Be(DeviceBindingType.None);

        // Get a single client
        var client = await fixture.ApiClient.Clients.GetAsync(newClientResponse.ClientId);
        client.Should().NotBeNull();
        client.Name.Should().Be(updateClientResponse.Name);
        client.DefaultOrganization.OrganizationId.Should().Be(existingOrganizationId);
        client.DefaultOrganization.Flows.Should().HaveCount(1);
        client.DefaultOrganization.Flows.First().Should().Be(Flows.ClientCredentials);
        client.RequirePushedAuthorizationRequests.Should().BeFalse();
        client.SignedRequestObject.Required.Should().BeFalse();
        client.ComplianceLevel.Should().Be(ComplianceLevel.NONE);
        client.TokenQuota.ClientCredentials.Enforce.Should().Be(false);
        client.SessionTransfer.Should().NotBeNull();
        client.SessionTransfer?.AllowRefreshToken.Should().BeFalse();
        client.SessionTransfer?.EnforceCascadeRevocation.Should().BeFalse();
        client.SessionTransfer?.EnforceOnlineRefreshTokens.Should().BeFalse();
        client.SessionTransfer?.CanCreateSessionTransferToken.Should().BeFalse();
        client.SessionTransfer?.AllowedAuthenticationMethods.Should().BeEquivalentTo(["query"]);
        client.SessionTransfer?.EnforceDeviceBinding.Should().Be(DeviceBindingType.None);

        // Delete the client, and ensure we get exception when trying to fetch client again
        await fixture.ApiClient.Clients.DeleteAsync(client.ClientId);
        Func<Task> getFunc = async () => await fixture.ApiClient.Clients.GetAsync(client.ClientId);
        getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_client");
    }

    [Fact]
    public async Task Test_client_rotate_secret()
    {
        // Add a new client
        var newClientRequest = new ClientCreateRequest
        {
            Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
            IsFirstParty = true,
            ClientMetaData = new
            {
                Prop1 = "1",
                Prop2 = "2"
            },
            ApplicationType = ClientApplicationType.Native
        };
        var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);
        fixture.TrackIdentifier(CleanUpType.Clients, newClientResponse.ClientId);

        // Rotate the secret
        var updateClientResponse = await fixture.ApiClient.Clients.RotateClientSecret(newClientResponse.ClientId);

        // Assert
        updateClientResponse.ClientSecret.Should().NotBe(newClientResponse.ClientSecret);

        // Delete the client, and ensure we get exception when trying to fetch client again
        await fixture.ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
    }

    [Fact]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo());

        // Assert
        Assert.Null(clients.Paging);
    }

    [Fact]
    public async Task Test_paging_does_not_include_totals()
    {
        // Act
        var clients =
            await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, false));

        // Assert
        Assert.Null(clients.Paging);
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var clients =
            await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest(), new PaginationInfo(0, 50, true));

        // Assert
        Assert.NotNull(clients.Paging);
    }

    [Fact]
    public async Task Test_without_paging()
    {
        // Act
        var clients = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest());

        // Assert
        Assert.Null(clients.Paging);
        Assert.True(clients.Count > 0);
    }

    [Fact]
    public async Task Test_app_type_works_correctly()
    {
        // Add a new client
        var newClientRequest = new ClientCreateRequest
        {
            Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            TokenEndpointAuthMethod = TokenEndpointAuthMethod.ClientSecretPost,
            IsFirstParty = true,
            ClientMetaData = new
            {
                Prop1 = "1",
                Prop2 = "2"
            },
            ApplicationType = ClientApplicationType.Native
        };
        var newClientResponse = await fixture.ApiClient.Clients.CreateAsync(newClientRequest);
        fixture.TrackIdentifier(CleanUpType.Clients, newClientResponse.ClientId);

        // Rotate the secret
        var connections = await fixture.ApiClient.Clients.GetAllAsync(new GetClientsRequest
        {
            AppType = new[] { ClientApplicationType.Native }
        }, new PaginationInfo());

        // Assert
        connections.Count.Should().BeGreaterThan(0);

        // Delete the client, and ensure we get exception when trying to fetch client again
        await fixture.ApiClient.Clients.DeleteAsync(newClientResponse.ClientId);
    }


    [Fact]
    public async Task Test_crud_credentials()
    {
        var newClient = await fixture.ApiClient.Clients.CreateAsync(new ClientCreateRequest
        {
            Name = $"{TestingConstants.ClientPrefix} {TestBaseUtils.MakeRandomName()}",
            ApplicationType = ClientApplicationType.RegularWeb,
            JwtConfiguration = new JwtConfiguration
            {
                SigningAlgorithm = "RS256"
            },
            ClientAuthenticationMethods = new CreateClientAuthenticationMethods
            {
                PrivateKeyJwt = new CreatePrivateKeyJwt
                {
                    Credentials = new List<ClientCredentialCreateRequest>
                    {
                        new()
                        {
                            CredentialType = "public_key",
                            Name = "Test Credential 1",
                            Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048)),
                        }
                    }
                }
            }
        });
        fixture.TrackIdentifier(CleanUpType.Clients, newClient.ClientId);
        newClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials.Should().NotBeNull();
        newClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials.Should().NotBeEmpty();
        newClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials[0].Id.Should().NotBeNull();

        var allCredentialsForClient = await fixture.ApiClient.Clients.GetAllCredentialsAsync(newClient.ClientId);
        var credential1 = await fixture.ApiClient.Clients.GetCredentialAsync(newClient.ClientId,
            newClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials[0].Id);

        allCredentialsForClient.Should().NotBeNull();
        allCredentialsForClient.Should().NotBeEmpty();
        allCredentialsForClient.Count.Should().Be(1);
        allCredentialsForClient.Select(x => x.Id).Should().Contain(credential1.Id);

        credential1.Name.Should().Be("Test Credential 1");
        credential1.CredentialType.Should().Be("public_key");

        var newCredential = await fixture.ApiClient.Clients.CreateCredentialAsync(newClient.ClientId,
            new ClientCredentialCreateRequest
            {
                CredentialType = "public_key",
                Name = "Test Credential 2",
                Pem = RsaTestUtils.ExportPublicKey(new RSACryptoServiceProvider(2048)),
            });


        newCredential.ExpiresAt.Should().BeNull();

        var newExpiry = DateTime.UtcNow.AddDays(2);
        var newExpiryWithoutMilliSeconds = new DateTime(
            newExpiry.Ticks - (newExpiry.Ticks % TimeSpan.TicksPerSecond),
            newExpiry.Kind
        );
        var newCredential2 = await fixture.ApiClient.Clients.UpdateCredentialAsync(newClient.ClientId, newCredential.Id,
            new ClientCredentialUpdateRequest { ExpiresAt = newExpiryWithoutMilliSeconds });

        newCredential2.ExpiresAt?.ToString("o").Should().Be(newExpiryWithoutMilliSeconds.ToString("o"));

        var credential2 = await fixture.ApiClient.Clients.GetCredentialAsync(newClient.ClientId, newCredential.Id);

        credential2.Name.Should().Be("Test Credential 2");
        credential2.CredentialType.Should().Be("public_key");

        var updatedClient = await fixture.ApiClient.Clients.UpdateAsync(newClient.ClientId, new ClientUpdateRequest
        {
            ClientAuthenticationMethods = new ClientAuthenticationMethods
            {
                PrivateKeyJwt = new PrivateKeyJwt
                {
                    Credentials = new List<CredentialId>
                    {
                        new()
                        {
                            Id = credential1.Id
                        },
                        new()
                        {
                            Id = credential2.Id
                        }
                    }
                }
            }
        });

        updatedClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials.Should().NotBeNull();
        updatedClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials.Should().NotBeEmpty();
        updatedClient.ClientAuthenticationMethods.PrivateKeyJwt.Credentials.Count.Should().Be(2);

        allCredentialsForClient = await fixture.ApiClient.Clients.GetAllCredentialsAsync(newClient.ClientId);

        allCredentialsForClient.Should().NotBeNull();
        allCredentialsForClient.Should().NotBeEmpty();
        allCredentialsForClient.Count.Should().Be(2);
        allCredentialsForClient.Select(x => x.Id).Should().Contain(credential1.Id);
        allCredentialsForClient.Select(x => x.Id).Should().Contain(credential2.Id);

        updatedClient = await fixture.ApiClient.Clients.UpdateAsync(newClient.ClientId, new ClientUpdateRequest
        {
            ClientAuthenticationMethods = new ClientAuthenticationMethods
            {
                PrivateKeyJwt = new PrivateKeyJwt
                {
                    Credentials = new List<CredentialId>
                    {
                    }
                }
            }
        });

        await fixture.ApiClient.Clients.DeleteCredentialAsync(newClient.ClientId, credential2.Id);
        await fixture.ApiClient.Clients.DeleteCredentialAsync(newClient.ClientId, credential1.Id);

        allCredentialsForClient = await fixture.ApiClient.Clients.GetAllCredentialsAsync(newClient.ClientId);

        allCredentialsForClient.Should().NotBeNull();
        allCredentialsForClient.Should().BeEmpty();
    }

    [Fact]
    public async Task Test_GetEnabledConnectionsForClient()
    {
        var enabledConnections =
            await fixture.ApiClient.Clients.GetEnabledConnectionsForClientAsync(
                TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                new EnabledConnectionsForClientGetRequest()
                {
                    IncludeFields = true,
                    Strategy = new[] { "google-oauth2", "auth0" },
                },
                new CheckpointPaginationInfo()
            );
        enabledConnections.Should().NotBeNull();
        enabledConnections.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetEnabledConnectionsForClientAsync_WithNullId_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            fixture.ApiClient.Clients.GetEnabledConnectionsForClientAsync(null, null, null));
    }

    [Fact]
    public async Task GetEnabledConnectionsForClientAsync_WithEmptyStrategyArray_DoesNotPassStrategyInQuery()
    {
        var clientId = "client123";
        var request = new EnabledConnectionsForClientGetRequest { Strategy = new string[0] };

        var mockConnection = new Mock<IManagementConnection>();
        mockConnection.Setup(c => c.GetAsync<ICheckpointPagedList<Connection>>(
                It.Is<Uri>(uri => !uri.Query.Contains("strategy=")),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonConverter[]>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new CheckpointPagedList<Connection>());

        var client = new ClientsClient(mockConnection.Object, new Uri("https://test.auth0.com"),
            new Dictionary<string, string>());

        await client.GetEnabledConnectionsForClientAsync(clientId, request, null);

        mockConnection.Verify();
    }

    [Fact]
    public async Task GetEnabledConnectionsForClientAsync_WithAllParameters_PassesAllParametersInQuery()
    {
        var clientId = "client123";
        var request = new EnabledConnectionsForClientGetRequest
        {
            Fields = "id,name",
            IncludeFields = true,
            Strategy = new[] { "auth0", "google-oauth2" }
        };
        var pagination = new CheckpointPaginationInfo(10, "token");

        var mockConnection = new Mock<IManagementConnection>();
        mockConnection.Setup(c => c.GetAsync<ICheckpointPagedList<Connection>>(
                It.Is<Uri>(uri =>
                    uri.Query.Contains("fields=id%2Cname") &&
                    uri.Query.Contains("include_fields=true") &&
                    uri.Query.Contains("strategy=auth0") &&
                    uri.Query.Contains("strategy=google-oauth2") &&
                    uri.Query.Contains("from=token") &&
                    uri.Query.Contains("take=10")),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonConverter[]>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new CheckpointPagedList<Connection>());

        var client = new ClientsClient(mockConnection.Object, new Uri("https://test.auth0.com"),
            new Dictionary<string, string>());

        await client.GetEnabledConnectionsForClientAsync(clientId, request, pagination);

        mockConnection.Verify();
    }
}