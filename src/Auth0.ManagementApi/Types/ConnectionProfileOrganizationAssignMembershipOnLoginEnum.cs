using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(StringEnumSerializer<ConnectionProfileOrganizationAssignMembershipOnLoginEnum>)
)]
[Serializable]
public readonly record struct ConnectionProfileOrganizationAssignMembershipOnLoginEnum : IStringEnum
{
    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum None = new(
        Values.None
    );

    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum Optional = new(
        Values.Optional
    );

    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum Required = new(
        Values.Required
    );

    public ConnectionProfileOrganizationAssignMembershipOnLoginEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ConnectionProfileOrganizationAssignMembershipOnLoginEnum FromCustom(string value)
    {
        return new ConnectionProfileOrganizationAssignMembershipOnLoginEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value
    ) => value.Value;

    public static explicit operator ConnectionProfileOrganizationAssignMembershipOnLoginEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
