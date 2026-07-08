using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum.EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum NeverSetEmailsAsVerified =
        new(Values.NeverSetEmailsAsVerified);

    public static readonly EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum AlwaysSetEmailsAsVerified =
        new(Values.AlwaysSetEmailsAsVerified);

    public EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
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
        EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value,
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
