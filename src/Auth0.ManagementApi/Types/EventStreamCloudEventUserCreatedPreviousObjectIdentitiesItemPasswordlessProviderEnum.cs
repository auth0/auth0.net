using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Email =
        new(Values.Email);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Sms =
        new(Values.Sms);

    public EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
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
        public const string Email = "email";

        public const string Sms = "sms";
    }
}
