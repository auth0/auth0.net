using Auth0.AuthenticationApi.Models;
using System;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Client for communicating with the Auth0 Authentication API.
    /// </summary>
    /// <remarks>
    /// Full documentation for the Authentication API is available at https://auth0.com/docs/auth-api
    /// </remarks>
    public interface IAuthenticationApiClient
    {
        /// <summary>
        /// Base URI that will be used for all the requests.
        /// </summary>
        Uri BaseUri { get; }

        /// <summary>
        /// Requests a password change email for a given email address and connection.
        /// </summary>
        /// <param name="request"><see cref="ChangePasswordRequest" /> specifying the user, connection and optional client details.</param>
        /// <returns><see cref="Task{string}"/> representing the async operation containing either the JSON error response or the plain text success message response.</returns>
        Task<string> ChangePasswordAsync(ChangePasswordRequest request);

        /// <summary>
        /// Obtains a one-time link that can be used to log in as a specific user.
        /// </summary>
        /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
        /// <returns><see cref="Task{Uri}"/> representing the async operation containing a <see cref="{Url}"/> which can be used to sign in as the specified user.</returns>
        /// <remarks>This feature has been deprecated and will be removed from Auth0 and this library in a future release.</remarks>
        Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request);

        /// <summary>
        /// Returns user information based on the access token that was obtained during login.
        /// </summary>
        /// <param name="accessToken">Access token used to obtain the user information.</param>
        /// <returns><see cref="Task{UserInfo}"/> representing the async operation containing the
        /// <see cref="UserInfo"/> requested..</returns>
        /// <remarks>Information included in the response depends on the scopes initially granted.</remarks>
        Task<UserInfo> GetUserInfoAsync(string accessToken);

        /// <summary>
        /// Exchanges an Authorization Code for an Access Token.
        /// </summary>
        /// <param name="request"><see cref="AuthorizationCodeTokenRequest"/> containing Authorization Code details.</param>
        /// <returns><see cref="Task{AccessTokenResponse}"/> representing the async operation containing 
        /// a <see cref="AccessTokenResponse"> with the requested tokens.</returns>
        Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request);

        /// <summary>
        /// Exchanges an Authorization Code using PKCE for an Access Token.
        /// </summary>
        /// <param name="request"><see cref="AuthorizationCodePkceTokenRequest"/> containing Authorization Code and PKCE details.</param>
        /// <returns><see cref="Task{AccessTokenResponse}"/> representing the async operation containing 
        /// a <see cref="AccessTokenResponse"> with the requested tokens.</returns>
        Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodePkceTokenRequest request);

        /// <summary>
        /// Requests an Access Token using the Client Credentials Grant flow.
        /// </summary>
        /// <param name="request"><see cref="ClientCredentialsTokenRequest"/> containing
        /// client and audience details of the request.</param>
        /// <returns><see cref="Task{AccessTokenResponse}"/> representing the async operation containing 
        /// a <see cref="AccessTokenResponse"> with the requested tokens.</returns>
        Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request);

        /// <summary>
        /// Refreshes all tokens by way of the the Refresh Token obtained during authorization.
        /// </summary>
        /// <param name="request"><see cref="RefreshTokenRequest"/> containing Refresh Token and associated parameters.</param>
        /// <returns><see cref="Task{AccessTokenResponse}"/> representing the async operation containing 
        /// a <see cref="AccessTokenResponse"> with the requested tokens.</returns>
        Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request);

        /// <summary>
        /// Performs authentication by providing user-supplied information in a <see cref="ResourceOwnerTokenRequest"/>.
        /// </summary>
        /// <param name="request"><see cref="ResourceOwnerTokenRequest"/> containing information regarding the username, password etc.</param>
        /// <returns><see cref="Task{AccessTokenResponse}"/> representing the async operation containing 
        /// a <see cref="AccessTokenResponse"> with the requested tokens.</returns>
        /// <remarks>
        /// The grant_type parameter required by the /oauth/token endpoint will automatically be inferred from the <paramref name="request"/> parameter. If no Realm was specified,
        /// then the grant_type will be set to "password". If a Realm was specified, then the grant_type will be set to "http://auth0.com/oauth/grant-type/password-realm"
        /// </remarks>
        Task<AccessTokenResponse> GetTokenAsync(ResourceOwnerTokenRequest request);

        /// <summary>
        /// Creates a new user given the user details specified.
        /// </summary>
        /// <param name="request"><see cref="SignupUserRequest" /> containing information of the user to sign up.</param>
        /// <returns><see cref="Task{SignupUserResponse}"/> representing the async operation containing 
        /// a <see cref="SignupUserResponse" /> with the information of the signed up user.</returns>
        Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request);

        /// <summary>
        /// Starts a new Passwordless email flow.
        /// </summary>
        /// <param name="request"><see cref="PasswordlessEmailRequest" /> containing details about the Passwordless email flow to start.</param>
        /// <returns><see cref="Task{PasswordlessEmailResponse}"/> representing the async operation containing 
        /// a <see cref="PasswordlessEmailResponse" /> with the information of the signed up user.</returns>
        /// <returns><see cref="Task{PasswordlessEmailResponse}"/> representing the async operation containing 
        /// a <see cref="PasswordlessEmailResponse" /> with the details of the request.</returns>
        Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request);

        /// <summary>
        /// Starts a new Passwordless SMS flow.
        /// </summary>
        /// <param name="request"><see cref="PasswordlessSmsRequest" /> containing details about the Passwordless SMS flow to start.</param>
        /// <returns><see cref="Task{PasswordlessSmsResponse}"/> representing the async operation containing 
        /// a <see cref="PasswordlessSmsResponse" /> with the details of the request.</returns>
        Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request);

        /// <summary>
        /// Unlinks a secondary account from a primary account.
        /// </summary>
        /// <param name="request"><see cref="UnlinkUserRequest"/> containing details of the accounts to unlink.</param>
        /// <returns><see cref="Task"/> representing the async unlink operation.</returns>
        Task UnlinkUserAsync(UnlinkUserRequest request);
    }
}