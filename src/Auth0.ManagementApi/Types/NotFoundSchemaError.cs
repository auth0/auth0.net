using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(NotFoundSchemaError.NotFoundSchemaErrorSerializer))]
[Serializable]
public readonly record struct NotFoundSchemaError : IStringEnum
{
    public static readonly NotFoundSchemaError NotFound = new(Values.NotFound);

    public NotFoundSchemaError(string value)
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
    public static NotFoundSchemaError FromCustom(string value)
    {
        return new NotFoundSchemaError(value);
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

    public static bool operator ==(NotFoundSchemaError value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotFoundSchemaError value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotFoundSchemaError value) => value.Value;

    public static explicit operator NotFoundSchemaError(string value) => new(value);

    internal class NotFoundSchemaErrorSerializer : JsonConverter<NotFoundSchemaError>
    {
        public override NotFoundSchemaError Read(
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
            return new NotFoundSchemaError(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotFoundSchemaError value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotFoundSchemaError ReadAsPropertyName(
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
            return new NotFoundSchemaError(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotFoundSchemaError value,
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
        public const string NotFound = "Not Found";
    }
}
