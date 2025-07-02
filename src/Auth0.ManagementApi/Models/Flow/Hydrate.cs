using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Flow;

/// <summary>
/// Hydration param
/// </summary>
public enum Hydrate
{
    [EnumMember(Value = "form_count")]
    FORM_COUNT,
        
    [EnumMember(Value = "debug")]
    DEBUG,
        
}