using System.Collections.Generic;

using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Tokens;

internal class AsymmetricSignedDecoder : SignedDecoder
{
    public AsymmetricSignedDecoder(IList<JsonWebKey> keys)
        : base(JwtSignatureAlgorithm.RS256, keys)
    {
    }
}