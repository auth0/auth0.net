using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Token Encryption
/// </summary>
public class TokenEncryption
{
    /// <summary>
    /// <inheritdoc cref="TokenFormat"/> 
    /// </summary>
    [JsonProperty("format")]
    [JsonConverter(typeof(StringEnumConverter))]
    public TokenFormat Format { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="TokenEncryptionKey"/>
    /// </summary>
    [JsonProperty("encryption_key")]
    public TokenEncryptionKey EncryptionKey { get; set; }
}

/// <summary>
/// Format of the encrypted JWT payload.
/// </summary>
public enum TokenFormat
{
    /// <summary>
    /// Token Format 'compact-nested-jwe'
    /// </summary>
    [EnumMember(Value = "compact-nested-jwe")]
    CompactNestedJwe,
}

/// <summary>
/// Encryption Key
/// </summary>
public class TokenEncryptionKey
{
    /// <summary>
    /// Name of the encryption key.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Algorithm used to encrypt the token.
    /// Possible values: [RSA-OAEP-256, RSA-OAEP-384, RSA-OAEP-512]
    /// </summary>
    [JsonProperty("alg")]
    public string Algorithm { get; set; }
        
    /// <summary>
    /// Key ID.
    /// </summary>
    [JsonProperty("kid")]
    public string Kid { get; set; }
        
    /// <summary>
    /// PEM-formatted public key. Must be JSON escaped.
    /// </summary>
    [JsonProperty("pem")]
    public string Pem { get; set; }
}