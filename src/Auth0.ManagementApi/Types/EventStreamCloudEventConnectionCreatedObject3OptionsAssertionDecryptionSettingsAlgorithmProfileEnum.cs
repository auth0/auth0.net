using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum.EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum V20261 =
        new(Values.V20261);

    public EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
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
        EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettingsAlgorithmProfileEnum value,
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
