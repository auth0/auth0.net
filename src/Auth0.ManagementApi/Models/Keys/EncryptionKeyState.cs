using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Keys;

/// <summary>
/// Encryption Key State
/// </summary>
public enum EncryptionKeyState
{
    [EnumMember(Value = "pre-activation")]
    PreActivation,
        
    [EnumMember(Value = "active")]
    Active,
        
    [EnumMember(Value = "deactivated")]
    Deactivated,
        
    [EnumMember(Value = "destroyed")]
    Destroyed,
}