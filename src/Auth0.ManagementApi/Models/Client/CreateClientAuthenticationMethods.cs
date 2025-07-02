using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Structure for creating new client authentication methods
/// </summary>
public class CreateClientAuthenticationMethods
{
    [JsonProperty("private_key_jwt")]
    public CreatePrivateKeyJwt PrivateKeyJwt { get; set; }
        
    [JsonProperty("tls_client_auth")]
    public CreateTlsClientAuth TlsClientAuthMethod { get; set; }
        
    [JsonProperty("self_signed_tls_client_auth")]
    public CreateSelfSignedTlsClientAuth SelfSignedTlsClientAuthMethod { get; set; }
}

/// <summary>
/// Structure for creating a new client credential using Private Key JWT
/// </summary>
public class CreatePrivateKeyJwt
{
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.ClientCredentialCreateRequest"/>
    /// </summary>
    [JsonProperty("credentials")]
    public IList<ClientCredentialCreateRequest> Credentials { get; set; }
}
    
/// <summary>
/// Structure for creating a new client credential using TLS Client Auth. 
/// </summary>
public class CreateTlsClientAuth
{
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.CreateTlsClientAuthCredentials"/>
    /// </summary>
    [JsonProperty("credentials")]
    public IList<CreateTlsClientAuthCredentials> Credentials { get; set; }
}
    
/// <summary>
/// Structure for creating a new client credential using Self Signed TLS Client Auth. 
/// </summary>
public class CreateSelfSignedTlsClientAuth
{
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.CreateSelfSignedTlsClientAuthCredentials"/>
    /// </summary>
    [JsonProperty("credentials")]
    public IList<CreateSelfSignedTlsClientAuthCredentials> Credentials { get; set; }
}