namespace Auth0.ManagementApi.Models.Keys;

/// <summary>
/// Contains information required for creating a wrapping key.
/// </summary>
public class WrappingKeyCreateRequest
{
    /// <summary>
    /// Encryption key ID
    /// </summary>
    public string Kid { get; set; }
}