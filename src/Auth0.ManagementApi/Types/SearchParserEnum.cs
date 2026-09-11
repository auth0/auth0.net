using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SearchParserEnum.SearchParserEnumSerializer))]
[Serializable]
public readonly record struct SearchParserEnum : IStringEnum
{
    public static readonly SearchParserEnum Scim = new(Values.Scim);

    public static readonly SearchParserEnum Lucene = new(Values.Lucene);

    public SearchParserEnum(string value)
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
    public static SearchParserEnum FromCustom(string value)
    {
        return new SearchParserEnum(value);
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

    public static bool operator ==(SearchParserEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchParserEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchParserEnum value) => value.Value;

    public static explicit operator SearchParserEnum(string value) => new(value);

    internal class SearchParserEnumSerializer : JsonConverter<SearchParserEnum>
    {
        public override SearchParserEnum Read(
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
            return new SearchParserEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SearchParserEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SearchParserEnum ReadAsPropertyName(
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
            return new SearchParserEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SearchParserEnum value,
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
        public const string Scim = "scim";

        public const string Lucene = "lucene";
    }
}
