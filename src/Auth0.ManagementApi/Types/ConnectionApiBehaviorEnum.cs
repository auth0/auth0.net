using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionApiBehaviorEnum>))]
[Serializable]
public readonly record struct ConnectionApiBehaviorEnum : IStringEnum
{
    public static readonly ConnectionApiBehaviorEnum Required = new(Values.Required);

    public static readonly ConnectionApiBehaviorEnum Optional = new(Values.Optional);

    public ConnectionApiBehaviorEnum(string value)
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
    public static ConnectionApiBehaviorEnum FromCustom(string value)
    {
        return new ConnectionApiBehaviorEnum(value);
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

    public static bool operator ==(ConnectionApiBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionApiBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionApiBehaviorEnum value) => value.Value;

    public static explicit operator ConnectionApiBehaviorEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Required = "required";

        public const string Optional = "optional";
    }
}
