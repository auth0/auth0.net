using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal interface ISignatureVerifier
    {
        Task<JwtSecurityToken> VerifySignatureAsync(string token);
    }
}
