using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Async approval notification channels for a client
/// </summary>
public enum AsyncApprovalNotificationChannels
{
    /// <summary>
    /// Client uses Guardian Push notification channel with CIBA flow
    /// </summary>
    [EnumMember(Value = "guardian-push")]
    GuardianPush,

    /// <summary>
    /// Client uses email notification channel with CIBA flow
    /// </summary>
    [EnumMember(Value = "email")]
    Email
}