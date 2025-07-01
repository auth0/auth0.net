using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Models.Ciba;
using Auth0.AuthenticationApi.Models.Mfa;

namespace Auth0.AuthenticationApi;

/// <summary>
/// Client for communicating with the Auth0 Authentication API.
/// </summary>
/// <remarks>
/// Full documentation for the Authentication API is available at https://auth0.com/docs/auth-api
/// </remarks>
public interface IAuthenticationApiClient : IDisposable
{
    /// <summary>
    /// Base URI that will be used for all the requests.
    /// </summary>
    Uri BaseUri { get; }

    /// <summary>
    /// Requests a password change email for a given email address and connection.
    /// </summary>
    /// <param name="request"><see cref="ChangePasswordRequest" /> specifying the user, connection and optional client details.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing either the JSON error response or the plain text success message response.</returns>
    Task<string> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtains a one-time link that can be used to log in as a specific user.
    /// </summary>
    /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> which can be used to sign in as the specified user.</returns>
    /// <remarks>This feature has been deprecated and will be removed from Auth0 and this library in a future release.</remarks>
    Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns user information based on the access token that was obtained during login.
    /// </summary>
    /// <param name="accessToken">Access token used to obtain the user information.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing the
    /// <see cref="UserInfo"/> requested..</returns>
    /// <remarks>Information included in the response depends on the scopes initially granted.</remarks>
    Task<UserInfo> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exchanges an Authorization Code for an Access Token.
    /// </summary>
    /// <param name="request"><see cref="AuthorizationCodeTokenRequest"/> containing Authorization Code details.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exchanges an Authorization Code using PKCE for an Access Token.
    /// </summary>
    /// <param name="request"><see cref="AuthorizationCodePkceTokenRequest"/> containing Authorization Code and PKCE details.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodePkceTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using the Client Credentials Grant flow.
    /// </summary>
    /// <param name="request"><see cref="ClientCredentialsTokenRequest"/> containing
    /// client and audience details of the request.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refreshes all tokens by way of the the Refresh Token obtained during authorization.
    /// </summary>
    /// <param name="request"><see cref="RefreshTokenRequest"/> containing Refresh Token and associated parameters.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Performs authentication by providing user-supplied information in a <see cref="ResourceOwnerTokenRequest"/>.
    /// </summary>
    /// <param name="request"><see cref="ResourceOwnerTokenRequest"/> containing information regarding the username, password etc.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    /// <remarks>
    /// The grant_type parameter required by the /oauth/token endpoint will automatically be inferred from the <paramref name="request"/> parameter. If no Realm was specified,
    /// then the grant_type will be set to "password". If a Realm was specified, then the grant_type will be set to "http://auth0.com/oauth/grant-type/password-realm"
    /// </remarks>
    Task<AccessTokenResponse> GetTokenAsync(ResourceOwnerTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using the Passwordless flow through email.
    /// </summary>
    /// <param name="request"><see cref="PasswordlessEmailTokenRequest"/> containing request details to exchange a one time password received through email.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(PasswordlessEmailTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using the Passwordless flow through SMS.
    /// </summary>
    /// <param name="request"><see cref="PasswordlessSmsTokenRequest"/> containing request details to exchange a one time password received through SMS.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    Task<AccessTokenResponse> GetTokenAsync(PasswordlessSmsTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using the Device Authorization flow
    /// </summary>
    /// <param name="request"><see cref="DeviceCodeTokenRequest"/> containing request details to exchange a device code.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="AccessTokenResponse" /> with the requested tokens.</returns>
    /// <remarks>
    /// This must be polled while the user is completing their part of the flow at an interval no more frequent than that returned by <see cref="StartDeviceFlowAsync" />.
    /// </remarks>
    Task<AccessTokenResponse> GetTokenAsync(DeviceCodeTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes refresh token provided in request.
    /// </summary>
    /// <param name="request"><see cref="RevokeRefreshTokenRequest"/> containing Refresh Token and associated parameters.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation.</returns>
    Task RevokeRefreshTokenAsync(RevokeRefreshTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user given the user details specified.
    /// </summary>
    /// <param name="request"><see cref="SignupUserRequest" /> containing information of the user to sign up.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="SignupUserResponse" /> with the information of the signed up user.</returns>
    Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a new Passwordless email flow.
    /// </summary>
    /// <param name="request"><see cref="PasswordlessEmailRequest" /> containing details about the Passwordless email flow to start.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="PasswordlessEmailResponse" /> with the information of the signed up user.</returns>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="PasswordlessEmailResponse" /> with the details of the request.</returns>
    Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a new Passwordless SMS flow.
    /// </summary>
    /// <param name="request"><see cref="PasswordlessSmsRequest" /> containing details about the Passwordless SMS flow to start.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="PasswordlessSmsResponse" /> with the details of the request.</returns>
    Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a new Device Authorization flow
    /// </summary>
    /// <param name="request"><see cref="DeviceCodeRequest"/> containing client, scope and audience</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="DeviceCodeResponse" /> with the details of the request.</returns>
    Task<DeviceCodeResponse> StartDeviceFlowAsync(DeviceCodeRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a new Pushed Authorization Request flow.
    /// </summary>
    /// <param name="request"><see cref="PushedAuthorizationRequest"/> containing information to start the Pushed Authorization Request.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="PushedAuthorizationRequestResponse" /> with the details of the response.</returns>
    Task<PushedAuthorizationRequestResponse> PushedAuthorizationRequestAsync(PushedAuthorizationRequest request,
        CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Initiates a Client Initiated Backchannel Authorization flow.
    /// </summary>
    /// <param name="request"><see cref="ClientInitiatedBackchannelAuthorizationRequest"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="ClientInitiatedBackchannelAuthorizationResponse" /> with the details of the response.</returns>
    Task<ClientInitiatedBackchannelAuthorizationResponse> ClientInitiatedBackchannelAuthorization(ClientInitiatedBackchannelAuthorizationRequest request,
        CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Requests an Access Token using the CIBA flow
    /// </summary>
    /// <param name="request"><see cref="ClientInitiatedBackchannelAuthorizationTokenRequest"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="ClientInitiatedBackchannelAuthorizationTokenResponse" /> with the requested tokens.</returns>
    /// <remarks>
    /// This must be polled while the user is completing their part of the flow at an interval no more frequent than that returned by <see cref="ClientInitiatedBackchannelAuthorizationResponse"/>.
    /// </remarks>
    Task<ClientInitiatedBackchannelAuthorizationTokenResponse> GetTokenAsync(ClientInitiatedBackchannelAuthorizationTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Associates or adds a new authenticator for Multi-Factor authentication (MFA).
    /// </summary>
    /// <param name="request"><see cref="AssociateMfaAuthenticatorRequest"/> containing information to enroll a new Authenticator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="AssociateMfaAuthenticatorResponse" /> with the details of the response.</returns>
    Task<AssociateMfaAuthenticatorResponse> AssociateMfaAuthenticatorAsync(AssociateMfaAuthenticatorRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// List authenticators associated with your application.
    /// </summary>
    /// <param name="accessToken">
    /// Access token with
    /// scope: read:authenticators and
    /// audience: https://{yourDomain}/mfa/
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>
    /// List of <see cref="Auth0.AuthenticationApi.Models.Mfa.Authenticator"/>
    /// </returns>
    Task<IList<Authenticator>> ListMfaAuthenticatorsAsync(string accessToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an associated authenticator using its ID.
    /// </summary>
    /// <param name="request"><see cref="DeleteMfaAuthenticatorRequest"/> containing information to
    /// delete an associated authenticator</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    Task DeleteMfaAuthenticatorAsync(DeleteMfaAuthenticatorRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using Oob MFA verification.
    /// </summary>
    /// <param name="request"><see cref="MfaOobTokenRequest"/> containing request details to verify oob.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns><see cref="Task"/> representing the async operation containing 
    /// a <see cref="MfaOobTokenResponse" /> with the requested tokens.</returns>
    Task<MfaOobTokenResponse> GetTokenAsync(MfaOobTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests an Access Token using OTP MFA verification.
    /// </summary>
    /// <param name="request"><see cref="MfaOtpTokenRequest"/> containing request details to verify otp.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns> An <see cref="MfaOtpTokenResponse" /> with the requested tokens.</returns>
    Task<MfaOtpTokenResponse> GetTokenAsync(MfaOtpTokenRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies multi-factor authentication (MFA) using a recovery code.
    /// </summary>
    /// <param name="request"><see cref="MfaRecoveryCodeRequest"/> containing request details to verify recovery code.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns> An <see cref="MfaRecoveryCodeResponse" /> with the requested tokens.</returns>
    Task<MfaRecoveryCodeResponse> GetTokenAsync(MfaRecoveryCodeRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// The Multi-factor Authentication (MFA) API endpoints allow you to enforce MFA when users interact with the Token endpoints, as well as enroll and manage user authenticators.
    /// </summary>
    /// <param name="request"><see cref="MfaChallengeRequest"/> containing request details to challenge.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation</param>
    /// <returns> An <see cref="MfaRecoveryCodeResponse" /> with the requested tokens</returns>
    Task<MfaChallengeResponse> MfaChallenge(MfaChallengeRequest request, CancellationToken cancellationToken = default);
}