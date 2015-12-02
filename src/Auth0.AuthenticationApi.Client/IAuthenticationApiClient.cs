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
        Task<SignupUserResponse> SignupUser(SignupUserRequest request);

        Task<PasswordlessEmailResponse> StartPasswordlessEmailFlow(PasswordlessEmailRequest request);

        Task<PasswordlessSmsResponse> StartPasswordlessSmsFlow(PasswordlessSmsRequest request);
    }
}