using System.Threading.Tasks;
using Auth0.AuthenticationApi.Builders;
using Auth0.AuthenticationApi.Models;
using Auth0.Core;
using System;
using System.ComponentModel;

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
        /// Given an <see cref="AuthenticationRequest"/>, it will do the authentication on the provider and return an <see cref="AccessToken"./>
        /// </summary>
        /// <param name="request">The authentication request details containing information regarding the connection, username, password etc.</param>
        /// <returns>A Task object with <see cref="AccessToken"/> which contains the token response.</returns>
        Task<AccessToken> AuthenticateAsync(AuthenticationRequest request);

        /// <summary>
        /// Creates a <see cref="AuthorizationUrlBuilder"/> which is used to build an authorization URL.
        /// </summary>
        /// <returns>A new <see cref="AuthorizationUrlBuilder"/> instance.</returns>
        AuthorizationUrlBuilder BuildAuthorizationUrl();

        /// <summary>
        /// Creates a <see cref="LogoutUrlBuilder"/> which is used to build a logout URL.
        /// </summary>
        /// <returns>A new <see cref="LogoutUrlBuilder"/> instance.</returns>
        LogoutUrlBuilder BuildLogoutUrl();

        /// <summary>
        /// Creates a <see cref="SamlUrlBuilder" /> which is used to build a SAML authentication URL.
        /// </summary>
        /// <param name="client">The name of the client.</param>
        /// <returns>A new <see cref="SamlUrlBuilder" /> instance.</returns>
        SamlUrlBuilder BuildSamlUrl(string client);

        /// <summary>
        /// Creates a <see cref="WsFedUrlBuilder"/> which is used to build a WS-FED authentication URL.
        /// </summary>
        /// <returns>A new <see cref="WsFedUrlBuilder"/> instance.</returns>
        WsFedUrlBuilder BuildWsFedUrl();

        /// <summary>
        /// Given the user's details, Auth0 will send a forgot password email.
        /// </summary>
        /// <param name="request">The <see cref="ChangePasswordRequest"/> specifying the user and connection details.</param>
        /// <returns>A task object with a string containing the message returned from Auth0.</returns>
        Task<string> ChangePasswordAsync(ChangePasswordRequest request);

        /// <summary>
        /// Exhanges an OAuth authorization code for an access token. This needs to be called as part of the OAuth authentication process, after the user has
        /// authenticated and the redirect URI is called with an authorization code. 
        /// </summary>
        /// <param name="request">The <see cref="ExchangeCodeRequest"/> containing the authorization code and other information needed to exchange the code for an access token.</param>
        /// <returns></returns>
        Task<AccessToken> ExchangeCodeForAccessTokenAsync(ExchangeCodeRequest request);

        /// <summary>
        /// Given the social provider's access token and the connection specified, it will do the authentication on the provider and return an <see cref="AccessToken"/>.
        /// </summary>
        /// <remarks>
        /// Currently, this endpoint only works for Facebook, Google, Twitter and Weibo.
        /// </remarks>
        /// <param name="request">The <see cref="AccessTokenRequest"/> containing details about the request.</param>
        /// <returns>The <see cref="AccessToken"/>.</returns>
        Task<AccessToken> GetAccessTokenAsync(AccessTokenRequest request);

        /// <summary>
        /// Given an existing token, this endpoint will generate a new token signed with the target client secret. This is used to flow the identity of the user from the application to an API or across different APIs that are protected with different secrets.
        /// </summary>
        /// <param name="request">The <see cref="DelegationRequestBase"/> containing details about the request.</param>
        /// <returns>The <see cref="AccessToken"/>.</returns>
        Task<AccessToken> GetDelegationTokenAsync(DelegationRequestBase request);

        /// <summary>
        /// Generates a link that can be used once to log in as a specific user.
        /// </summary>
        /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
        /// <returns>A <see cref="Uri"/> which can be used to sign in as the specified user.</returns>
        Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request);

        /// <summary>
        /// Returns the SAML 2.0 meta data for a client.
        /// </summary>
        /// <param name="clientId">The client (App) ID for which meta data must be returned.</param>
        /// <returns>The meta data XML .</returns>
        Task<string> GetSamlMetadataAsync(string clientId);

        /// <summary>
        /// Returns the user information based on the Auth0 access token (obtained during login).
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The <see cref="UserInfo"/> associated with the token.</returns>
        Task<UserInfo> GetUserInfoAsync(string accessToken);

        /// <summary>
        /// Returns the WS Federation meta data.
        /// </summary>
        /// <returns>The meta data XML</returns>
        Task<string> GetWsFedMetadataAsync();

        /// <summary>
        /// Given the user credentials, the connection specified and the Auth0 account information, it will create a new user. 
        /// </summary>
        /// <param name="request">The <see cref="SignupUserRequest"/> containing information of the user to sign up.</param>
        /// <returns>A <see cref="SignupUserResponse"/> with the information of the signed up user.</returns>
        Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request);

        /// <summary>
        /// Starts a new Passwordless email flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessEmailRequest"/> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessEmailResponse"/> containing the response.</returns>
        Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request);

        /// <summary>
        /// Starts a new Passwordless SMS flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessSmsRequest"/> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessSmsResponse"/> containing the response.</returns>
        Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request);

        /// <summary>
        /// Unlinks a secondary account from a primary account.
        /// </summary>
        /// <param name="request">The <see cref="UnlinkUserRequest"/> containing the information of the accounts to unlink.</param>
        /// <returns>Nothing</returns>
        Task UnlinkUserAsync(UnlinkUserRequest request);

        /// <summary>
        /// Given an <see cref="UsernamePasswordLoginRequest"/>, it will do the authentication on the provider and return a <see cref="UsernamePasswordLoginResponse"/>
        /// </summary>
        /// <param name="request">The authentication request details containing information regarding the connection, username, password etc.</param>
        /// <returns>A <see cref="UsernamePasswordLoginResponse"/> containing the WS-Federation Login Form, which can be posted by the user to trigger a server-side login.</returns>
        Task<UsernamePasswordLoginResponse> UsernamePasswordLoginAsync(UsernamePasswordLoginRequest request);

        /// <summary>
        /// Given a <see cref="TokenRefreshRequest"/>, it will retrieve a refreshed access token from the authorization server.
        /// </summary>
        /// <param name="request">The refresh token request details, containing a valid refresh token.</param>
        /// <returns>The new token issued by the server.</returns>
        Task<AccessToken> GetRefreshedTokenAsync(TokenRefreshRequest request);
    }
}