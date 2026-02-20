using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionSignupBehaviorEnum>))]
[Serializable]
public readonly record struct ConnectionSignupBehaviorEnum : IStringEnum
{
    public static readonly ConnectionSignupBehaviorEnum Allow = new(Values.Allow);

    public static readonly ConnectionSignupBehaviorEnum Block = new(Values.Block);

    public ConnectionSignupBehaviorEnum(string value)
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
    public static ConnectionSignupBehaviorEnum FromCustom(string value)
    {
        return new ConnectionSignupBehaviorEnum(value);
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

    public static bool operator ==(ConnectionSignupBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionSignupBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionSignupBehaviorEnum value) => value.Value;

    public static explicit operator ConnectionSignupBehaviorEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Allow = "allow";

        public const string Block = "block";
    }
}
