namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Represents possible signing algorithms for JsonWebTokens (JWTs).
    /// </summary>
    public enum JwtSignatureAlgorithm
    {
        /// <summary>
        /// RS256 asymmetric algorithm verified using public key via JWKS.
        /// </summary>
        RS256,

        /// <summary>
        /// HS256 symmetric algorithm verified using client secret.
        /// </summary>
        /// <remarks>
        /// Should only be used in environments where a client secret can be kept secure.
        /// e.g. Web server-side applications.  NOT mobile or desktop.
        /// </remarks>
        HS256
    }
}