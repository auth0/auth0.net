using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;

namespace Auth0.AuthenticationApi.Client
{
    public interface IAuthenticationApiClient
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);

        Task<Uri> BuildAuthorizationUri(BuildAuthorizationUriRequest request);

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

        Task<SignupUserResponse> SignupUser(SignupUserRequest request);

        Task<PasswordlessEmailResponse> StartPasswordlessEmailFlow(PasswordlessEmailRequest request);

        Task<PasswordlessSmsResponse> StartPasswordlessSmsFlow(PasswordlessSmsRequest request);
    }
}