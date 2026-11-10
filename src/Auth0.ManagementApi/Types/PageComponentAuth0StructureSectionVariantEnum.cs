using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PageComponentAuth0StructureSectionVariantEnum.PageComponentAuth0StructureSectionVariantEnumSerializer)
)]
[Serializable]
public readonly record struct PageComponentAuth0StructureSectionVariantEnum : IStringEnum
{
    public static readonly PageComponentAuth0StructureSectionVariantEnum Card = new(Values.Card);

    public static readonly PageComponentAuth0StructureSectionVariantEnum None = new(Values.None);

    public PageComponentAuth0StructureSectionVariantEnum(string value)
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
    public static PageComponentAuth0StructureSectionVariantEnum FromCustom(string value)
    {
        return new PageComponentAuth0StructureSectionVariantEnum(value);
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
        PageComponentAuth0StructureSectionVariantEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PageComponentAuth0StructureSectionVariantEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PageComponentAuth0StructureSectionVariantEnum value) =>
        value.Value;

    public static explicit operator PageComponentAuth0StructureSectionVariantEnum(string value) =>
        new(value);

    internal class PageComponentAuth0StructureSectionVariantEnumSerializer
        : JsonConverter<PageComponentAuth0StructureSectionVariantEnum>
    {
        public override PageComponentAuth0StructureSectionVariantEnum Read(
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
            return new PageComponentAuth0StructureSectionVariantEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PageComponentAuth0StructureSectionVariantEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PageComponentAuth0StructureSectionVariantEnum ReadAsPropertyName(
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
            return new PageComponentAuth0StructureSectionVariantEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PageComponentAuth0StructureSectionVariantEnum value,
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
        public const string Card = "card";

        public const string None = "none";
    }
}
