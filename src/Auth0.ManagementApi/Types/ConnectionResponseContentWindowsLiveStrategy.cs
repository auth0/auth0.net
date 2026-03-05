using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentWindowsLiveStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentWindowsLiveStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentWindowsLiveStrategy Windowslive = new(
        Values.Windowslive
    );

    public ConnectionResponseContentWindowsLiveStrategy(string value)
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
    public static ConnectionResponseContentWindowsLiveStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentWindowsLiveStrategy(value);
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
        ConnectionResponseContentWindowsLiveStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentWindowsLiveStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentWindowsLiveStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentWindowsLiveStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Windowslive = "windowslive";
    }
}
