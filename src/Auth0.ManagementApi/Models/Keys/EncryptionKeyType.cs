using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Keys;

/// <summary>
/// Encryption Key Type
/// </summary>
public enum EncryptionKeyType
{
    [EnumMember(Value = "customer-provided-root-key")]
    CustomerProvidedRootKey,
        
    [EnumMember(Value = "environment-root-key")]
    EnvironmentRootKey,
        
    [EnumMember(Value = "tenant-master-key")]
    TenantMasterKey,
        
    [EnumMember(Value = "tenant-encryption-key")]
    TenantEncryptionKey,
}