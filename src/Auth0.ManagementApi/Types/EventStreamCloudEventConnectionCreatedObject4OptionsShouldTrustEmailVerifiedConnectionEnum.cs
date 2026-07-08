using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum.EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum NeverSetEmailsAsVerified =
        new(Values.NeverSetEmailsAsVerified);

    public static readonly EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum AlwaysSetEmailsAsVerified =
        new(Values.AlwaysSetEmailsAsVerified);

    public EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
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
        EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject4OptionsShouldTrustEmailVerifiedConnectionEnum value,
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
