using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum Auth0 =
        new(Values.Auth0);

    public EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum(
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
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum(
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
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabaseProviderEnum value,
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
        public const string Auth0 = "auth0";
    }
}
