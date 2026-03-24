using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentBaiduStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentBaiduStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentBaiduStrategy Baidu = new(Values.Baidu);

    public ConnectionResponseContentBaiduStrategy(string value)
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
    public static ConnectionResponseContentBaiduStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentBaiduStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentBaiduStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentBaiduStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentBaiduStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentBaiduStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Baidu = "baidu";
    }
}
