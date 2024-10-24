namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Algorithm used to sign JWTs. Can be HS256 or RS256. PS256 available via addon.
    /// </summary>
    public enum SigningAlgorithm
    {
        /// <summary>
        /// HS256 symmetrical (requires client secret)
        /// </summary>
        HS256,

        /// <summary>
        /// RS256 asymmetrical (requires access to JWKS public keys)
        /// </summary>
        RS256,
        
        /// <summary>
        /// PS256 available via addon. 
        /// </summary>
        PS256
    }
}