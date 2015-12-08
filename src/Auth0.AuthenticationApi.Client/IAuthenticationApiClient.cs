using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Builders;
using Auth0.AuthenticationApi.Client.Models;
using Auth0.Core;

namespace Auth0.AuthenticationApi.Client
{
    public interface IAuthenticationApiClient
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);

        AuthorizationUrlBuilder BuildAuthorizationUrl();

        LogoutUrlBuilder BuildLogoutUrl();

        SamlUrlBuilder BuildSamlUrl(string client);

        WsFedUrlBuilder BuildWsFedUrl();

        Task<string> ChangePassword(ChangePasswordRequest request);

        /// <summary>
        /// Given the social provider's access token and the connection specified, it will do the authentication on the provider and return an <see cref="AccessToken"/>.
        /// </summary>
        /// <remarks>
        ///  Currently, this endpoint only works for Facebook, Google, Twitter and Weibo.
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AccessToken> GetAccessToken(AccessTokenRequest request);

        Task<AccessToken> GetDelegationToken(DelegationRequestBase request);

        Task<string> GetSamlMetadata(string clientId);

        /// <summary>
        /// Returns the user information based on the Auth0 access token (obtained during login).
        /// </summary>
        /// <returns></returns>
        Task<User> GetUserInfo(string accessToken);

        /// <summary>
        /// Validates a JSON Web Token (signature and expiration) and returns the user information associated with the user id (sub property) of the token.
        /// </summary>
        /// <returns></returns>
        Task<User> GetTokenInfo(string idToken);

        Task<string> GetWsFedMetadata();

        Task<SignupUserResponse> SignupUser(SignupUserRequest request);

        Task<PasswordlessEmailResponse> StartPasswordlessEmailFlow(PasswordlessEmailRequest request);

        Task<PasswordlessSmsResponse> StartPasswordlessSmsFlow(PasswordlessSmsRequest request);
    }
}