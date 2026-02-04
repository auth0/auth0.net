using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionPasswordPolicyEnum>))]
[Serializable]
public readonly record struct ConnectionPasswordPolicyEnum : IStringEnum
{
    public static readonly ConnectionPasswordPolicyEnum None = new(Values.None);

    public static readonly ConnectionPasswordPolicyEnum Low = new(Values.Low);

    public static readonly ConnectionPasswordPolicyEnum Fair = new(Values.Fair);

    public static readonly ConnectionPasswordPolicyEnum Good = new(Values.Good);

    public static readonly ConnectionPasswordPolicyEnum Excellent = new(Values.Excellent);

    public ConnectionPasswordPolicyEnum(string value)
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
    public static ConnectionPasswordPolicyEnum FromCustom(string value)
    {
        return new ConnectionPasswordPolicyEnum(value);
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

    public static bool operator ==(ConnectionPasswordPolicyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionPasswordPolicyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionPasswordPolicyEnum value) => value.Value;

    public static explicit operator ConnectionPasswordPolicyEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";

        public const string Low = "low";

        public const string Fair = "fair";

        public const string Good = "good";

        public const string Excellent = "excellent";
    }
}
