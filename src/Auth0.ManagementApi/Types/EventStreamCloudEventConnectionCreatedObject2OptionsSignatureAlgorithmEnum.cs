using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum.EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum RsaSha1 =
        new(Values.RsaSha1);

    public static readonly EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum RsaSha256 =
        new(Values.RsaSha256);

    public EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum(
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
        EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject2OptionsSignatureAlgorithmEnum value,
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
