using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PageComponentAuth0StructureSeparatorVariantEnum.PageComponentAuth0StructureSeparatorVariantEnumSerializer)
)]
[Serializable]
public readonly record struct PageComponentAuth0StructureSeparatorVariantEnum : IStringEnum
{
    public static readonly PageComponentAuth0StructureSeparatorVariantEnum Dashed = new(
        Values.Dashed
    );

    public static readonly PageComponentAuth0StructureSeparatorVariantEnum None = new(Values.None);

    public static readonly PageComponentAuth0StructureSeparatorVariantEnum Solid = new(
        Values.Solid
    );

    public PageComponentAuth0StructureSeparatorVariantEnum(string value)
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
    public static PageComponentAuth0StructureSeparatorVariantEnum FromCustom(string value)
    {
        return new PageComponentAuth0StructureSeparatorVariantEnum(value);
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
        PageComponentAuth0StructureSeparatorVariantEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PageComponentAuth0StructureSeparatorVariantEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PageComponentAuth0StructureSeparatorVariantEnum value) =>
        value.Value;

    public static explicit operator PageComponentAuth0StructureSeparatorVariantEnum(string value) =>
        new(value);

    internal class PageComponentAuth0StructureSeparatorVariantEnumSerializer
        : JsonConverter<PageComponentAuth0StructureSeparatorVariantEnum>
    {
        public override PageComponentAuth0StructureSeparatorVariantEnum Read(
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
            return new PageComponentAuth0StructureSeparatorVariantEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PageComponentAuth0StructureSeparatorVariantEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PageComponentAuth0StructureSeparatorVariantEnum ReadAsPropertyName(
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
            return new PageComponentAuth0StructureSeparatorVariantEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PageComponentAuth0StructureSeparatorVariantEnum value,
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
        public const string Dashed = "dashed";

        public const string None = "none";

        public const string Solid = "solid";
    }
}
