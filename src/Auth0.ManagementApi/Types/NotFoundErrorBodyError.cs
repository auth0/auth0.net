using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(NotFoundErrorBodyError.NotFoundErrorBodyErrorSerializer))]
[Serializable]
public readonly record struct NotFoundErrorBodyError : IStringEnum
{
    public static readonly NotFoundErrorBodyError NotFound = new(Values.NotFound);

    public NotFoundErrorBodyError(string value)
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
    public static NotFoundErrorBodyError FromCustom(string value)
    {
        return new NotFoundErrorBodyError(value);
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

    public static bool operator ==(NotFoundErrorBodyError value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NotFoundErrorBodyError value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NotFoundErrorBodyError value) => value.Value;

    public static explicit operator NotFoundErrorBodyError(string value) => new(value);

    internal class NotFoundErrorBodyErrorSerializer : JsonConverter<NotFoundErrorBodyError>
    {
        public override NotFoundErrorBodyError Read(
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
            return new NotFoundErrorBodyError(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NotFoundErrorBodyError value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NotFoundErrorBodyError ReadAsPropertyName(
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
            return new NotFoundErrorBodyError(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NotFoundErrorBodyError value,
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
