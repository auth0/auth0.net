using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum.EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum V20261 =
        new(Values.V20261);

    public EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
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
        EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value,
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
        public const string V20261 = "v2026-1";
    }
}
