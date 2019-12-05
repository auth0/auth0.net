using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class SymmetricSignedDecoder : SignedDecoder
    {
        public SymmetricSignedDecoder(string clientSecret)
            : base(JwtSignatureAlgorithm.HS256, new [] { new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientSecret)) })
        {
        }
    }
}
