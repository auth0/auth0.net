using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentMiicardStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentMiicardStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentMiicardStrategy Miicard = new(Values.Miicard);

    public ConnectionResponseContentMiicardStrategy(string value)
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
    public static ConnectionResponseContentMiicardStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentMiicardStrategy(value);
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
        ConnectionResponseContentMiicardStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentMiicardStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentMiicardStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentMiicardStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Miicard = "miicard";
    }
}
