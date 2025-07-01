using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Structure for a client's authentication methods
/// </summary>
public class ClientAuthenticationMethods
{
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.PrivateKeyJwt"/> 
    /// </summary>
    [JsonProperty("private_key_jwt")]
    public PrivateKeyJwt PrivateKeyJwt { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.TlsClientAuth"/> 
    /// </summary>
    [JsonProperty("tls_client_auth")]
    public TlsClientAuth TlsClientAuth { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.SelfSignedTlsClientAuth"/> 
    /// </summary>
    [JsonProperty("self_signed_tls_client_auth")]
    public SelfSignedTlsClientAuth SelfSignedTlsClientAuth { get; set; }
}

/// <summary>
/// Defines private_key_jwt client authentication method. If this property is defined,
/// the client is enabled to use the Private Key JWT authentication method.
/// </summary>
public class PrivateKeyJwt
{
    [JsonProperty("credentials")]
    public IList<CredentialId> Credentials { get; set; }
}
    
/// <summary>
/// Defines tls_client_auth client authentication method. If the property is defined,
/// the client is configured to use CA-based mTLS authentication method.
/// </summary>
public class TlsClientAuth
{
    [JsonProperty("credentials")]
    public IList<CredentialId> Credentials { get; set; }
}
    
/// <summary>
/// Defines self_signed_tls_client_auth client authentication method. If the property is defined,
/// the client is configured to use mTLS authentication method utilizing self-signed certificate.
/// </summary>
public class SelfSignedTlsClientAuth
{
    [JsonProperty("credentials")]
    public IList<CredentialId> Credentials { get; set; }
}

/// <summary>
/// Structure for a client's credential.
/// </summary>
/// <remarks>
/// Only contains the credential's id.
/// </remarks>
public class CredentialId
{
    [JsonProperty("id")]
    public string Id { get; set; }
}