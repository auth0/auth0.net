using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<EventStreamWebhookBearerAuthMethodEnum>))]
[Serializable]
public readonly record struct EventStreamWebhookBearerAuthMethodEnum : IStringEnum
{
    public static readonly EventStreamWebhookBearerAuthMethodEnum Bearer = new(Values.Bearer);

    public EventStreamWebhookBearerAuthMethodEnum(string value)
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
    public static EventStreamWebhookBearerAuthMethodEnum FromCustom(string value)
    {
        return new EventStreamWebhookBearerAuthMethodEnum(value);
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

    public static bool operator ==(EventStreamWebhookBearerAuthMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamWebhookBearerAuthMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamWebhookBearerAuthMethodEnum value) =>
        value.Value;

    public static explicit operator EventStreamWebhookBearerAuthMethodEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Bearer = "bearer";
    }
}
