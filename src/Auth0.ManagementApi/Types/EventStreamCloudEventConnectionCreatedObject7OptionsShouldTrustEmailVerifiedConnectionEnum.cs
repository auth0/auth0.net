using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum.EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum NeverSetEmailsAsVerified =
        new(Values.NeverSetEmailsAsVerified);

    public static readonly EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum AlwaysSetEmailsAsVerified =
        new(Values.AlwaysSetEmailsAsVerified);

    public EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
        string value
    )
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
    public static EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
            value
        );
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
        EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NeverSetEmailsAsVerified = "never_set_emails_as_verified";

        public const string AlwaysSetEmailsAsVerified = "always_set_emails_as_verified";
    }
}
