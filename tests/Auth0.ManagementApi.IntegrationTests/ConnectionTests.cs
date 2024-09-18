using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;
using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ConnectionTestsFixture : TestBaseFixture
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

    public class ConnectionTests : IClassFixture<ConnectionTestsFixture>
    {
        ConnectionTestsFixture fixture;

        public ConnectionTests(ConnectionTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_database_connection_crud_sequence()
        {
            // Get all connections before
            var connectionsBefore = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "auth0" }
            }, new PaginationInfo());

            // Create a new connection
            var name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
            var displayName = "displayname";
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = name,
                Strategy = "auth0",
                DisplayName = displayName,
                Realms = new[] { name }
            };
            var newConnectionResponse = await fixture.ApiClient.Connections.CreateAsync(newConnectionRequest);

            fixture.TrackIdentifier(CleanUpType.Connections, newConnectionResponse.Id);

            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);
            newConnectionResponse.Realms.Should().BeEquivalentTo(newConnectionRequest.Realms);
            newConnectionResponse.IsDomainConnection.Should().BeFalse();
            newConnectionResponse.DisplayName.Should().Be(newConnectionRequest.DisplayName);

            // Get all connections again
            var connectionsAfter = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "auth0" }
            }, new PaginationInfo());
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var newName = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}";
            var newDisplayName = "newdisplayname";
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                },
                Metadata = new
                {
                    b = "456"
                },
                Realms = new[] { newName },
                DisplayName = newDisplayName
            };
            var updateConnectionResponse = await fixture.ApiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            string a = updateConnectionResponse.Options.a;
            a.Should().Be("123");
            string b = updateConnectionResponse.Metadata.b;
            b.Should().Be("456");
            updateConnectionRequest.Realms.Should().BeEquivalentTo(new[] { newName });
            updateConnectionRequest.DisplayName.Should().BeEquivalentTo(newDisplayName);

            // Get a single connection
            var connection = await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();

            // Delete the connection and ensure we get exception when trying to get connection again
            await fixture.ApiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");


            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnectionResponse.Id);
        }

        [Fact]
        public async Task Test_connection_crud_sequence()
        {
            // Get all connections before
            var connectionsBefore = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            }, new PaginationInfo());

            // Create a new connection
            var newConnectionRequest = new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "github",
                DisplayName = "displayname"
            };
            var newConnectionResponse = await fixture.ApiClient.Connections.CreateAsync(newConnectionRequest);

            fixture.TrackIdentifier(CleanUpType.Connections, newConnectionResponse.Id);

            newConnectionResponse.Should().NotBeNull();
            newConnectionResponse.Name.Should().Be(newConnectionRequest.Name);
            newConnectionResponse.Strategy.Should().Be(newConnectionRequest.Strategy);
            newConnectionResponse.DisplayName.Should().Be(newConnectionRequest.DisplayName);

            // Get all connections again
            var connectionsAfter = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] {"github"}
            }, new PaginationInfo());
            connectionsAfter.Count.Should().Be(connectionsBefore.Count + 1);

            // Update a connection
            var newDisplayName = "newdisplayname";
            var updateConnectionRequest = new ConnectionUpdateRequest
            {
                Options = new
                {
                    a = "123"
                },
                Metadata = new
                {
                    b = "456"
                },
                DisplayName = newDisplayName
            };
            var updateConnectionResponse = await fixture.ApiClient.Connections.UpdateAsync(newConnectionResponse.Id, updateConnectionRequest);
            string a = updateConnectionResponse.Options.a;
            a.Should().Be("123");
            string b = updateConnectionResponse.Metadata.b;
            b.Should().Be("456");
            newDisplayName.Should().BeEquivalentTo(updateConnectionResponse.DisplayName);

            // Get a single connection
            var connection = await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            connection.Should().NotBeNull();

            // Delete the connection and ensure we get exception when trying to get connection again
            await fixture.ApiClient.Connections.DeleteAsync(newConnectionResponse.Id);
            Func<Task> getFunc = async () => await fixture.ApiClient.Connections.GetAsync(newConnectionResponse.Id);
            getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_connection");

            fixture.UnTrackIdentifier(CleanUpType.Connections, newConnectionResponse.Id);
        }

        [Fact]
        public async Task Test_when_paging_not_specified_does_not_include_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo());

            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_does_not_include_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, false));

            // Assert
            Assert.Null(connections.Paging);
        }

        [Fact]
        public async Task Test_paging_includes_totals()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest(), new PaginationInfo(0, 50, true));

            // Assert
            Assert.NotNull(connections.Paging);
        }

        [Fact]
        public async Task Test_multiple_strategies()
        {
            // Act
            var connections = await fixture.ApiClient.Connections.GetAllAsync(new GetConnectionsRequest
            {
                Strategy = new[] { "google-oauth2", "auth0" }
            }, new PaginationInfo());

            // Assert
            Assert.NotNull(connections);
        }

        [Fact]
        public async Task Test_scim_configuration_crud_sequence()
        {
            var expectedScimConfiguration = new ScimConfiguration()
            {
                Strategy = "samlp",
                ConnectionId = "con_wP6Ya7Fbp98JQXuY",
                ConnectionName = "fake-saml",
                TenantName = "brucke",
                UserIdAttribute = "string",
                Mapping = new List<ScimMapping>()
                {
                    new()
                    {
                        Auth0 = "string",
                        Scim = "string"
                    }
                }
            };

            var token = await GenerateBruckeManagementApiToken();
            var apiClient = new ManagementApiClient(token, TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_URL"),
                new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions
                    { NumberOfHttpRetries = 9 }));
            try
            {
                // Create an SCIM configuration
                await apiClient.Connections.CreateScimConfigurationAsync(
                    expectedScimConfiguration.ConnectionId, new ScimConfigurationCreateRequest()
                    {
                        UserIdAttribute = expectedScimConfiguration.UserIdAttribute,
                        Mapping = expectedScimConfiguration.Mapping
                    });

                // Get SCIM configuration and verify
                var scimConfiguration =
                    await apiClient.Connections.GetScimConfigurationAsync(expectedScimConfiguration.ConnectionId);

                AssertScimConfiguration(expectedScimConfiguration, scimConfiguration);

                // Update SCIM Configuration and Validate
                var updateRequest = new ScimConfigurationUpdateRequest()
                {
                    UserIdAttribute = "string",
                    Mapping = new List<ScimMapping>()
                    {
                        new()
                        {
                            Auth0 = "string",
                            Scim = "string"
                        },
                        new()
                        {
                            Auth0 = "int",
                            Scim = "int"
                        }
                    }

                };
                expectedScimConfiguration.UserIdAttribute = updateRequest.UserIdAttribute;
                scimConfiguration =
                    await apiClient.Connections.UpdateScimConfigurationAsync(
                        expectedScimConfiguration.ConnectionId, updateRequest);
                AssertScimConfiguration(expectedScimConfiguration, scimConfiguration);
            }
            finally
            {
                // Delete SCIM Configuration and Validate
                await apiClient.Connections.DeleteScimConfigurationAsync(expectedScimConfiguration.ConnectionId);    
            }
        }
        
        [Fact]
        public async Task Test_get_default_scim_configuration()
        {
            var expectedScimConfiguration = new ScimConfiguration()
            {
                Strategy = "samlp",
                ConnectionId = "con_wP6Ya7Fbp98JQXuY",
                ConnectionName = "fake-saml",
                TenantName = "brucke",
                UserIdAttribute = "string",
                Mapping = new List<ScimMapping>()
                {
                    new()
                    {
                        Auth0 = "random",
                        Scim = "random"
                    }
                }
            };

            var token = await GenerateBruckeManagementApiToken();
            var apiClient = new ManagementApiClient(token, TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_URL"),
                new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions
                    { NumberOfHttpRetries = 9 }));
            try
            {
                // Create an SCIM configuration
                await apiClient.Connections.CreateScimConfigurationAsync(
                    expectedScimConfiguration.ConnectionId, new ScimConfigurationCreateRequest()
                    {
                        UserIdAttribute = expectedScimConfiguration.UserIdAttribute,
                        Mapping = expectedScimConfiguration.Mapping
                    });

                var defaultScimMapping = await apiClient.Connections.GetDefaultScimMappingAsync(expectedScimConfiguration.ConnectionId);
                Assert.NotNull(defaultScimMapping);
            }
            finally
            {
                // Clean-up
                await apiClient.Connections.DeleteScimConfigurationAsync(expectedScimConfiguration.ConnectionId);
            }
        }
        
        [Fact]
        public async Task Test_scim_token_crud_sequence()
        {
            var expectedScimConfiguration = new ScimConfiguration()
            {
                Strategy = "samlp",
                ConnectionId = "con_wP6Ya7Fbp98JQXuY",
                ConnectionName = "fake-saml",
                TenantName = "brucke",
                UserIdAttribute = "string",
                Mapping = new List<ScimMapping>()
                {
                    new()
                    {
                        Auth0 = "random",
                        Scim = "random"
                    }
                }
            };

            var token = await GenerateBruckeManagementApiToken();
            var apiClient = new ManagementApiClient(token, TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_URL"),
                new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions
                    { NumberOfHttpRetries = 9 }));
            try
            {
                // Create an SCIM configuration
                await apiClient.Connections.CreateScimConfigurationAsync(
                    expectedScimConfiguration.ConnectionId, new ScimConfigurationCreateRequest()
                    {
                        UserIdAttribute = expectedScimConfiguration.UserIdAttribute,
                        Mapping = expectedScimConfiguration.Mapping
                    });

                var createTokenRequest = new ScimTokenCreateRequest()
                {
                    Scopes = new string[] { "openid", "offline_access" },
                    TokenLifetime = 1000
                };
                
                // Create two SCIM tokens and Validate
                var scimTokenOne = await CreateScimTokenAndValidate(createTokenRequest);
                var scimTokenTwo = await CreateScimTokenAndValidate(createTokenRequest);

                // Retrieve the token and validate
                var retrievedScimTokens = 
                    await apiClient.Connections.GetScimTokenAsync(expectedScimConfiguration.ConnectionId);
                Assert.Equal(scimTokenOne.Scopes, retrievedScimTokens[0].Scopes);
                Assert.Equal(scimTokenOne.TokenId, retrievedScimTokens[0].TokenId);
                Assert.Equal(scimTokenOne.CreatedAt, retrievedScimTokens[0].CreatedAt);
                Assert.Equal(scimTokenOne.ValidUntil, retrievedScimTokens[0].ValidUntil);
                
                Assert.Equal(scimTokenTwo.Scopes, retrievedScimTokens[1].Scopes);
                Assert.Equal(scimTokenTwo.TokenId, retrievedScimTokens[1].TokenId);
                Assert.Equal(scimTokenTwo.CreatedAt, retrievedScimTokens[1].CreatedAt);
                Assert.Equal(scimTokenTwo.ValidUntil, retrievedScimTokens[1].ValidUntil);
                
                // Delete SCIM Token and validate
                await apiClient.Connections.DeleteScimTokenAsync(expectedScimConfiguration.ConnectionId, scimTokenOne.TokenId);
                await apiClient.Connections.DeleteScimTokenAsync(expectedScimConfiguration.ConnectionId, scimTokenTwo.TokenId);
                var retrievedScimTokensAfterDelete = 
                    await apiClient.Connections.GetScimTokenAsync(expectedScimConfiguration.ConnectionId);
                Assert.Empty(retrievedScimTokensAfterDelete);
            }
            finally
            {
                // Clean-up
                await apiClient.Connections.DeleteScimConfigurationAsync(expectedScimConfiguration.ConnectionId);
            }

            async Task<ScimTokenCreateResponse> CreateScimTokenAndValidate(ScimTokenCreateRequest createTokenRequest)
            {
                var scimToken = 
                    await apiClient.Connections.CreateScimTokenAsync(expectedScimConfiguration.ConnectionId, createTokenRequest);
                Assert.NotNull(scimToken);
                Assert.NotNull(scimToken.Scopes);
                Assert.NotNull(scimToken.TokenId);
                Assert.NotNull(scimToken.Token);
                Assert.NotNull(scimToken.CreatedAt);
                Assert.NotNull(scimToken.ValidUntil);
                scimToken.Scopes.Should().HaveCount(2);
                Assert.Equal(createTokenRequest.Scopes, scimToken.Scopes);
                return scimToken;
            }
        }
        
        
        private async Task<string> GenerateBruckeManagementApiToken()
        {
            using var authenticationApiClient = 
                new TestAuthenticationApiClient(TestBaseUtils.GetVariable("BRUCKE_AUTHENTICATION_API_URL"));
            // Get the access token
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_SECRET"),
                Audience = TestBaseUtils.GetVariable("BRUCKE_MANAGEMENT_API_AUDIENCE")
            });

            return token.AccessToken;
        }

        private void AssertScimConfiguration(ScimConfiguration expectedScimConfiguration,
            ScimConfiguration actualScimConfiguration)
        {
            actualScimConfiguration.Should().NotBeNull();
            Assert.Equal(expectedScimConfiguration.ConnectionId, actualScimConfiguration.ConnectionId);
            Assert.Equal(expectedScimConfiguration.ConnectionName, actualScimConfiguration.ConnectionName);
            Assert.Equal(expectedScimConfiguration.TenantName, actualScimConfiguration.TenantName);
            Assert.Equal(expectedScimConfiguration.UserIdAttribute, actualScimConfiguration.UserIdAttribute);
            Assert.Equal(expectedScimConfiguration.Strategy, actualScimConfiguration.Strategy);
            Assert.NotNull(actualScimConfiguration.UpdatedOn);
            Assert.NotNull(actualScimConfiguration.CreatedAt);
        }
    }
}
