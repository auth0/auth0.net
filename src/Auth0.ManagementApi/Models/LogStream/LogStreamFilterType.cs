using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Filter type.
/// </summary>
public enum LogStreamFilterType
{
    [EnumMember(Value ="category")]
    Category
}