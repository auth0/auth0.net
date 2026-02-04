using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.IntegrationTests.Testing;
using Auth0.IntegrationTests.Shared.CleanUp;
using Xunit;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class DatabaseConnectionTestsFixture : TestBaseFixture
{
    public AuthenticationApiClient AuthenticationApiClient;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        AuthenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL"));
    }
    

    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
        
}

public class DatabaseConnectionTests : IClassFixture<DatabaseConnectionTestsFixture>
{
    private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

    private DatabaseConnectionTestsFixture fixture;

    public DatabaseConnectionTests(DatabaseConnectionTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Can_signup_user_and_change_password()
    {
        // We will need a connection to add the users to...
        var connection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, connection.Id);

        // Sign up the user
        var signupUserRequest = new SignupUserRequest
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            Connection = connection.Name,
            Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            Password = Password,
            FamilyName = "Surname",
            GivenName = "Forename",
            Name = "Full Name",
            Nickname = "Nick",
            Picture = new Uri("https://cdn.auth0.com/styleguide/components/1.0.8/media/logos/img/badge.png"),
            Username = "A User",
            UserMetadata = new
            {
                a = "1",
                b = "two"
            }
        };
        var signupUserResponse = await fixture.AuthenticationApiClient.SignupUserAsync(signupUserRequest);
        signupUserResponse.Should().NotBeNull();
        signupUserResponse.Id.Should().NotBeNull();
        signupUserResponse.EmailVerified.Should().BeFalse();
        signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        signupUserResponse.FamilyName.Should().Be(signupUserRequest.FamilyName);
        signupUserResponse.GivenName.Should().Be(signupUserRequest.GivenName);
        signupUserResponse.Name.Should().Be(signupUserRequest.Name);
        signupUserResponse.Nickname.Should().Be(signupUserRequest.Nickname);
        signupUserResponse.Picture.Should().Be(signupUserRequest.Picture);            
    }
        
    [Fact]
    public async Task Can_signup_user_with_phonenumber()
    {
        // We will need a connection that supports phone numbers
        var connection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            Options = GetConnectionOptionsRequest(),
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        fixture.TrackIdentifier(CleanUpType.Connections, connection.Id);
        // Sign up the user
        var signupUserRequest = new SignupUserRequest
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            Connection = connection.Name,
            Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            Password = Password,
            FamilyName = "Surname",
            GivenName = "Forename",
            Name = "Full Name",
            Nickname = "Nick",
            Picture = new Uri("https://cdn.auth0.com/styleguide/components/1.0.8/media/logos/img/badge.png"),
            Username = "A-User",
            UserMetadata = new
            {
                a = "1",
                b = "two"
            },
            PhoneNumber = "+911234567890"
        };
        var signupUserResponse = await fixture.AuthenticationApiClient.SignupUserAsync(signupUserRequest);
        signupUserResponse.Should().NotBeNull();
        signupUserResponse.Id.Should().NotBeNull();
        signupUserResponse.EmailVerified.Should().BeFalse();
        signupUserResponse.Email.Should().Be(signupUserRequest.Email);
        signupUserResponse.FamilyName.Should().Be(signupUserRequest.FamilyName);
        signupUserResponse.GivenName.Should().Be(signupUserRequest.GivenName);
        signupUserResponse.Name.Should().Be(signupUserRequest.Name);
        signupUserResponse.Nickname.Should().Be(signupUserRequest.Nickname);
        signupUserResponse.Picture.Should().Be(signupUserRequest.Picture);
        signupUserResponse.PhoneNumber.Should().Be(signupUserRequest.PhoneNumber);
    }

    [Fact]
    public async Task Signup_Response_Normalizes_Id_For_RegularDb()
    {
        // Sign up the user
        var signupUserRequest = new SignupUserRequest
        {
            ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
            Connection = "Username-Password-Authentication",
            Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            Password = Password
        };
        var signupUserResponse = await fixture.AuthenticationApiClient.SignupUserAsync(signupUserRequest);
        signupUserResponse.Should().NotBeNull();
        signupUserResponse.Id.Should().NotBeNull();
        signupUserResponse.Email.Should().Be(signupUserRequest.Email);
    }
        
    private ConnectionPropertiesOptions GetConnectionOptionsRequest()
    {
        var optionsRequestObject = new ConnectionPropertiesOptions()
        {
            Attributes = new ConnectionAttributes()
            {
                Email = new EmailAttribute()
                {
                    ProfileRequired = false,
                    Identifier = new ConnectionAttributeIdentifier()
                    {
                        Active = true
                    },
                    Signup = new SignupVerified()
                    {
                        Status = SignupStatusEnum.Optional,
                        Verification = new SignupVerification()
                        {
                            Active = false
                        }
                    }
                },
                PhoneNumber = new PhoneAttribute()
                {
                    ProfileRequired = true,
                    Identifier = new ConnectionAttributeIdentifier()
                    {
                        Active = true
                    },
                    Signup = new SignupVerified()
                    {
                        Status = SignupStatusEnum.Required,
                        Verification = new SignupVerification()
                        {
                            Active = false
                        }
                    }
                },
                Username = new UsernameAttribute()
                {
                    ProfileRequired = true,
                    Identifier = new ConnectionAttributeIdentifier()
                    {
                        Active = true
                    },
                    Signup = new SignupSchema()
                    {
                        Status = SignupStatusEnum.Required
                    },
                    Validation = new UsernameValidation()
                    {
                        MinLength = 5,
                        MaxLength = 10,
                        AllowedTypes = new UsernameAllowedTypes()
                        {
                            PhoneNumber = false,
                            Email = true
                        }
                    }
                }
            }
        };
        return optionsRequestObject;
    }
}