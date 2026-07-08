using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum.EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum Sha1 =
        new(Values.Sha1);

    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum Sha256 =
        new(Values.Sha256);

    public EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum value,
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
