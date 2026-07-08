using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum.EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum NeverSetEmailsAsVerified =
        new(Values.NeverSetEmailsAsVerified);

    public static readonly EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum AlwaysSetEmailsAsVerified =
        new(Values.AlwaysSetEmailsAsVerified);

    public EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
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
        EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject7OptionsShouldTrustEmailVerifiedConnectionEnum value,
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
