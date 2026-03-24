using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentAdfsStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentAdfsStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentAdfsStrategy Adfs = new(Values.Adfs);

    public ConnectionResponseContentAdfsStrategy(string value)
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
    public static ConnectionResponseContentAdfsStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentAdfsStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentAdfsStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentAdfsStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentAdfsStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentAdfsStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Adfs = "adfs";
    }
}
