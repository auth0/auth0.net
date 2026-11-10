using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(InternalServerErrorBodyError.InternalServerErrorBodyErrorSerializer))]
[Serializable]
public readonly record struct InternalServerErrorBodyError : IStringEnum
{
    public static readonly InternalServerErrorBodyError InternalServerError = new(
        Values.InternalServerError
    );

    public InternalServerErrorBodyError(string value)
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
    public static InternalServerErrorBodyError FromCustom(string value)
    {
        return new InternalServerErrorBodyError(value);
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

    public static bool operator ==(InternalServerErrorBodyError value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InternalServerErrorBodyError value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InternalServerErrorBodyError value) => value.Value;

    public static explicit operator InternalServerErrorBodyError(string value) => new(value);

    internal class InternalServerErrorBodyErrorSerializer
        : JsonConverter<InternalServerErrorBodyError>
    {
        public override InternalServerErrorBodyError Read(
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
            return new InternalServerErrorBodyError(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InternalServerErrorBodyError value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InternalServerErrorBodyError ReadAsPropertyName(
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
            return new InternalServerErrorBodyError(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InternalServerErrorBodyError value,
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
        public const string InternalServerError = "Internal Server Error";
    }
}
