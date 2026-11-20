using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(IncludeUserProfileSizeHeaderEnum.IncludeUserProfileSizeHeaderEnumSerializer))]
[Serializable]
public readonly record struct IncludeUserProfileSizeHeaderEnum : IStringEnum
{
    public static readonly IncludeUserProfileSizeHeaderEnum True = new(Values.True);

    public IncludeUserProfileSizeHeaderEnum(string value)
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
    public static IncludeUserProfileSizeHeaderEnum FromCustom(string value)
    {
        return new IncludeUserProfileSizeHeaderEnum(value);
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

    public static bool operator ==(IncludeUserProfileSizeHeaderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IncludeUserProfileSizeHeaderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IncludeUserProfileSizeHeaderEnum value) => value.Value;

    public static explicit operator IncludeUserProfileSizeHeaderEnum(string value) => new(value);

    internal class IncludeUserProfileSizeHeaderEnumSerializer
        : JsonConverter<IncludeUserProfileSizeHeaderEnum>
    {
        public override IncludeUserProfileSizeHeaderEnum Read(
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
            return new IncludeUserProfileSizeHeaderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IncludeUserProfileSizeHeaderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IncludeUserProfileSizeHeaderEnum ReadAsPropertyName(
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
            return new IncludeUserProfileSizeHeaderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IncludeUserProfileSizeHeaderEnum value,
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
        public const string True = "true";
    }
}
