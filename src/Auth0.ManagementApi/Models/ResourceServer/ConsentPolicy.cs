using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Possible values: [transactional-authorization-with-mfa, null]
/// </summary>
public enum ConsentPolicy
{
    /// <summary>
    /// Compliance Policy 'transactional-authorization-with-mfa'
    /// </summary>
    [EnumMember(Value = "transactional-authorization-with-mfa")]
    TransactionalAuthorizationWithMfa,
}