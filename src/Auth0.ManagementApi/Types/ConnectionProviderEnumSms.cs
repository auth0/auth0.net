using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionProviderEnumSms>))]
[Serializable]
public readonly record struct ConnectionProviderEnumSms : IStringEnum
{
    public static readonly ConnectionProviderEnumSms SmsGateway = new(Values.SmsGateway);

    public static readonly ConnectionProviderEnumSms Twilio = new(Values.Twilio);

    public ConnectionProviderEnumSms(string value)
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
    public static ConnectionProviderEnumSms FromCustom(string value)
    {
        return new ConnectionProviderEnumSms(value);
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

    public static bool operator ==(ConnectionProviderEnumSms value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionProviderEnumSms value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionProviderEnumSms value) => value.Value;

    public static explicit operator ConnectionProviderEnumSms(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SmsGateway = "sms_gateway";

        public const string Twilio = "twilio";
    }
}
