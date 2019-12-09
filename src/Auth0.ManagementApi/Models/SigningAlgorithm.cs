namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Alogithm a token can be signed with.
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
        RS256
    }
}