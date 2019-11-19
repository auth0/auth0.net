using System.IdentityModel.Tokens.Jwt;

namespace Auth0.AuthenticationApi.Tokens
{
    internal interface ISignatureVerifier
    {
        JwtSecurityToken VerifySignature(string token);
    }
}
