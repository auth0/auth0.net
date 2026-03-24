using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionResponseContentPaypalSandboxStrategy>))]
[Serializable]
public readonly record struct ConnectionResponseContentPaypalSandboxStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentPaypalSandboxStrategy PaypalSandbox = new(
        Values.PaypalSandbox
    );

    public ConnectionResponseContentPaypalSandboxStrategy(string value)
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
    public static ConnectionResponseContentPaypalSandboxStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentPaypalSandboxStrategy(value);
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
        ConnectionResponseContentPaypalSandboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentPaypalSandboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentPaypalSandboxStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentPaypalSandboxStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PaypalSandbox = "paypal-sandbox";
    }
}
