using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentPingFederateStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentPingFederateStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentPingFederateStrategy Pingfederate = new(
        Values.Pingfederate
    );

    public ConnectionResponseContentPingFederateStrategy(string value)
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
    public static ConnectionResponseContentPingFederateStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentPingFederateStrategy(value);
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
        ConnectionResponseContentPingFederateStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentPingFederateStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentPingFederateStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentPingFederateStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pingfederate = "pingfederate";
    }
}
