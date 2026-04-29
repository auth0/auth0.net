using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum Custom =
        new(Values.Custom);

    public EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum(string value)
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
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum(value);
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
        EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomProviderEnum value,
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
        public const string Custom = "custom";
    }
}
