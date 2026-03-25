using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(JobFileFormatEnum.JobFileFormatEnumSerializer))]
[Serializable]
public readonly record struct JobFileFormatEnum : IStringEnum
{
    public static readonly JobFileFormatEnum Json = new(Values.Json);

    public static readonly JobFileFormatEnum Csv = new(Values.Csv);

    public JobFileFormatEnum(string value)
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
    public static JobFileFormatEnum FromCustom(string value)
    {
        return new JobFileFormatEnum(value);
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

    public static bool operator ==(JobFileFormatEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(JobFileFormatEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(JobFileFormatEnum value) => value.Value;

    public static explicit operator JobFileFormatEnum(string value) => new(value);

    internal class JobFileFormatEnumSerializer : JsonConverter<JobFileFormatEnum>
    {
        public override JobFileFormatEnum Read(
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
            return new JobFileFormatEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            JobFileFormatEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override JobFileFormatEnum ReadAsPropertyName(
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
            return new JobFileFormatEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            JobFileFormatEnum value,
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
        public const string Json = "json";

        public const string Csv = "csv";
    }
}
