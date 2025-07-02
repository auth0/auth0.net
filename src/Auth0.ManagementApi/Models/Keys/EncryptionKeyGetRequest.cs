namespace Auth0.ManagementApi.Models.Keys;

/// <summary>
/// Contains information required for getting an encryption key.
/// </summary>
public class EncryptionKeyGetRequest
{
    /// <summary>
    /// Encryption key ID.
    /// </summary>
    public string Kid { get; set; }
}