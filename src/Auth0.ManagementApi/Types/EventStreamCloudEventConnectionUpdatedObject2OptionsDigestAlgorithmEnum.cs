using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum.EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum Sha1 =
        new(Values.Sha1);

    public static readonly EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum Sha256 =
        new(Values.Sha256);

    public EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum(value);
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
        EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject2OptionsDigestAlgorithmEnum value,
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
