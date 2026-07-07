using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum.EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum RsaSha1 =
        new(Values.RsaSha1);

    public static readonly EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum RsaSha256 =
        new(Values.RsaSha256);

    public EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum(
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
        EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject3OptionsSignatureAlgorithmEnum value,
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
        public const string RsaSha1 = "rsa-sha1";

        public const string RsaSha256 = "rsa-sha256";
    }
}
