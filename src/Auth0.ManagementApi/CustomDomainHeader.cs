namespace Auth0.ManagementApi;

/// <summary>
/// Provides constants related to the Auth0 custom domain HTTP header.
/// </summary>
/// <remarks>
/// Use this when constructing a <see cref="ManagementApiClient"/> with a custom domain.
/// The header is automatically included on whitelisted endpoints only.
/// </remarks>
public static class CustomDomainHeader
{
    /// <summary>
    /// The HTTP header name used to specify an Auth0 custom domain.
    /// </summary>
    public const string HeaderName = "Auth0-Custom-Domain";
}
