using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Email =
        new(Values.Email);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Sms =
        new(Values.Sms);

    public EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
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
