using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Structure for creating a new Credential for JAR request
/// </summary>
public class CredentialsCreateRequest
{
    /// <summary>
    /// Credential type. Supported types: public_key.
    /// </summary>
    [JsonProperty("credential_type")]
    public string CredentialType { get; set; }

    /// <summary>
    /// Friendly name for a credential.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// PEM-formatted public key (SPKI and PKCS1) or X509 certificate. Must be JSON escaped.
    /// </summary>
    [JsonProperty("pem")]
    public string Pem { get; set; }

    /// <summary>
    /// Algorithm which will be used with the credential. Can be one of RS256, RS384, PS256.
    /// If not specified, RS256 will be used.
    /// </summary>
    [JsonProperty("alg")]
    public string Algorithm { get; set; }

    /// <summary>
    /// Parse expiry from x509 certificate. If true, attempts to parse the expiry date from the provided PEM.
    /// </summary>
    [JsonProperty("parse_expiry_from_cert")]
    public bool ParseExpiryFromCert { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date representing the expiration of the credential.
    /// If not specified (not recommended), the credential never expires.
    /// </summary>
    [JsonProperty("expires_at")]
    public DateTime? ExpiresAt { get; set; }
}