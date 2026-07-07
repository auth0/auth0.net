using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum.EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum Sha1 =
        new(Values.Sha1);

    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum Sha256 =
        new(Values.Sha256);

    public EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum(value);
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
        EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsDigestAlgorithmEnum value,
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
        public const string Sha1 = "sha1";

        public const string Sha256 = "sha256";
    }
}
