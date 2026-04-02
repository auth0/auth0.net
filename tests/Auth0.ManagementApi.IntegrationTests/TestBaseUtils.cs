using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auth0.Tests.Shared;

public class TestBaseUtils
{
    /// <summary>
    /// Creates a CreateUserRequestContent with sensible defaults for integration tests.
    /// Optional fields that have SDK defaults are set to null to avoid sending unwanted values.
    /// </summary>
    public static CreateUserRequestContent CreateUserRequest(
        string connection,
        string email,
        bool emailVerified = true,
        string? password = null,
        string? userId = null)
    {
        return new CreateUserRequestContent
        {
            Connection = connection,
            Email = email,
            EmailVerified = emailVerified,
            Password = password,
            // Set SDK defaults to null/undefined so they won't be serialized
            PhoneNumber = null,
            PhoneVerified = null,
            UserId = userId,
            Username = null,
            GivenName = null,
            FamilyName = null,
            Name = null,
            Nickname = null,
            Picture = null,
            Blocked = null,
            VerifyEmail = null
        };
    }

    /// <summary>
    /// Creates a VerifyEmailTicketRequestContent with sensible defaults for integration tests.
    /// </summary>
    public static VerifyEmailTicketRequestContent CreateVerifyEmailTicketRequest(
        string userId,
        string? clientId = null)
    {
        return new VerifyEmailTicketRequestContent
        {
            UserId = userId,
            ClientId = clientId,
            // Set SDK defaults to null so they won't be serialized
            ResultUrl = null,
            OrganizationId = null
        };
    }

    /// <summary>
    /// Creates a ChangePasswordTicketRequestContent with sensible defaults for integration tests.
    /// </summary>
    public static ChangePasswordTicketRequestContent CreateChangePasswordTicketRequest(
        string? userId = null,
        string? clientId = null)
    {
        return new ChangePasswordTicketRequestContent
        {
            UserId = userId,
            ClientId = clientId,
            // Set SDK defaults to null so they won't be serialized
            ResultUrl = null,
            OrganizationId = null,
            ConnectionId = null,
            MarkEmailAsVerified = null
        };
    }

    /// <summary>
    /// Creates a CreateOrganizationInvitationRequestContent with sensible defaults for integration tests.
    /// </summary>
    public static Auth0.ManagementApi.Organizations.CreateOrganizationInvitationRequestContent CreateOrganizationInvitationRequest(
        Auth0.ManagementApi.OrganizationInvitationInviter inviter,
        Auth0.ManagementApi.OrganizationInvitationInvitee invitee,
        string clientId,
        bool sendInvitationEmail = false)
    {
        return new Auth0.ManagementApi.Organizations.CreateOrganizationInvitationRequestContent
        {
            Inviter = inviter,
            Invitee = invitee,
            ClientId = clientId,
            SendInvitationEmail = sendInvitationEmail,
            // Set SDK defaults to null so they won't be serialized
            ConnectionId = null
        };
    }

    /// <summary>
    /// Creates a CreateVerificationEmailRequestContent (Jobs API) with sensible defaults for integration tests.
    /// </summary>
    public static Auth0.ManagementApi.Jobs.CreateVerificationEmailRequestContent CreateVerificationEmailJobRequest(
        string userId,
        string? clientId = null,
        Auth0.ManagementApi.Identity? identity = null)
    {
        return new Auth0.ManagementApi.Jobs.CreateVerificationEmailRequestContent
        {
            UserId = userId,
            ClientId = clientId,
            Identity = identity,
            // Set SDK defaults to null so they won't be serialized
            OrganizationId = null
        };
    }

    /// <summary>
    /// Creates an UpdateUserRequestContent with sensible defaults for integration tests.
    /// All fields with SDK defaults are set to null/Undefined so they won't be serialized.
    /// </summary>
    public static UpdateUserRequestContent CreateUpdateUserRequest()
    {
        return new UpdateUserRequestContent
        {
            // Set SDK defaults to null/undefined so they won't be serialized
            Blocked = null,
            EmailVerified = null,
            Email = Optional<string?>.Undefined,
            PhoneNumber = Optional<string?>.Undefined,
            PhoneVerified = null,
            GivenName = Optional<string?>.Undefined,
            FamilyName = Optional<string?>.Undefined,
            Name = Optional<string?>.Undefined,
            Nickname = Optional<string?>.Undefined,
            Picture = Optional<string?>.Undefined,
            VerifyEmail = null,
            VerifyPhoneNumber = null,
            Password = Optional<string?>.Undefined,
            Connection = null,
            ClientId = null,
            Username = Optional<string?>.Undefined
        };
    }

    /// <summary>
    /// Creates a LinkUserIdentityRequestContent with sensible defaults for integration tests.
    /// </summary>
    public static Auth0.ManagementApi.Users.LinkUserIdentityRequestContent CreateLinkUserIdentityRequest(
        Auth0.ManagementApi.UserIdentityProviderEnum? provider = null,
        string? connectionId = null,
        string? userId = null)
    {
        return new Auth0.ManagementApi.Users.LinkUserIdentityRequestContent
        {
            Provider = provider,
            ConnectionId = connectionId,
            UserId = userId,
            // Set SDK defaults to null so they won't be serialized
            LinkWith = null
        };
    }

    /// <summary>
    /// Creates a CreateClientRequestContent with sensible defaults for integration tests.
    /// </summary>
    public static CreateClientRequestContent CreateClientRequest(
        string name,
        ClientAppTypeEnum? appType = null,
        IEnumerable<string>? grantTypes = null,
        ClientRefreshTokenConfiguration? refreshToken = null,
        ClientJwtConfiguration? jwtConfiguration = null,
        string? description = null,
        IEnumerable<string>? callbacks = null,
        IEnumerable<string>? allowedLogoutUrls = null)
    {
        var request = new CreateClientRequestContent
        {
            Name = name,
            AppType = appType,
            GrantTypes = grantTypes,
            JwtConfiguration = jwtConfiguration,
            Description = description,
            Callbacks = callbacks,
            AllowedLogoutUrls = allowedLogoutUrls,
            // Set SDK defaults to null so they won't be serialized
            IsTokenEndpointIpHeaderTrusted = null,
            IsFirstParty = null,
            OidcConformant = null,
            CrossOriginAuthentication = null,
            RequirePushedAuthorizationRequests = null,
            RequireProofOfPossession = null
        };
        // Only set Optional<T> properties if a value is provided, otherwise leave as Undefined
        if (refreshToken != null)
        {
            request.RefreshToken = refreshToken;
        }
        return request;
    }

    public static string GetVariable(string variableName, bool throwIfMissing = true)
    {
        var value = TestBase.Config[variableName];
        if (String.IsNullOrEmpty(value) && throwIfMissing)
            throw new ArgumentOutOfRangeException($"Configuration value '{variableName}' has not been set.");
        return value;
    }

    private static readonly Regex _alphaNumeric = new("[^a-zA-Z0-9]");

    public static string MakeRandomName()
    {
        return _alphaNumeric.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "");
    }

    public static async Task<string> GenerateManagementApiToken()
    {
        using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
        {
            // Get the access token
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
            });

            return token.AccessToken;
        }
    }
}