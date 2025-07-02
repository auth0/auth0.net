using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Defines the compliance level for this client, which may restrict it's capabilities
/// </summary>
public enum ComplianceLevel
{
    /// <summary>
    /// Compliance Level 'none'
    /// </summary>
    [EnumMember(Value = "none")]
    NONE,
        
    /// <summary>
    /// Compliance Level 'fapi1_adv_pkj_par'
    /// </summary>
    [EnumMember(Value = "fapi1_adv_pkj_par")]
    FAPI1_ADV_PKJ_PAR,
        
    /// <summary>
    /// Compliance Level 'fapi1_adv_mtls_par'
    /// </summary>
    [EnumMember(Value = "fapi1_adv_mtls_par")]
    FAPI1_ADV_MTLS_PAR
}