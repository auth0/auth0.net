using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum Email =
        new(Values.Email);

    public static readonly EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum Sms =
        new(Values.Sms);

    public EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
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
        EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum>
    {
        public override EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum Read(
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
            return new EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordlessProviderEnum value,
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
