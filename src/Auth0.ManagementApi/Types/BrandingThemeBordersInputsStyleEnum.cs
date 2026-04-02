using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BrandingThemeBordersInputsStyleEnum.BrandingThemeBordersInputsStyleEnumSerializer)
)]
[Serializable]
public readonly record struct BrandingThemeBordersInputsStyleEnum : IStringEnum
{
    public static readonly BrandingThemeBordersInputsStyleEnum Pill = new(Values.Pill);

    public static readonly BrandingThemeBordersInputsStyleEnum Rounded = new(Values.Rounded);

    public static readonly BrandingThemeBordersInputsStyleEnum Sharp = new(Values.Sharp);

    public BrandingThemeBordersInputsStyleEnum(string value)
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
    public static BrandingThemeBordersInputsStyleEnum FromCustom(string value)
    {
        return new BrandingThemeBordersInputsStyleEnum(value);
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

    public static bool operator ==(BrandingThemeBordersInputsStyleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandingThemeBordersInputsStyleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeBordersInputsStyleEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeBordersInputsStyleEnum(string value) => new(value);

    internal class BrandingThemeBordersInputsStyleEnumSerializer
        : JsonConverter<BrandingThemeBordersInputsStyleEnum>
    {
        public override BrandingThemeBordersInputsStyleEnum Read(
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
            return new BrandingThemeBordersInputsStyleEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingThemeBordersInputsStyleEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingThemeBordersInputsStyleEnum ReadAsPropertyName(
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
            return new BrandingThemeBordersInputsStyleEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingThemeBordersInputsStyleEnum value,
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
        public const string Pill = "pill";

        public const string Rounded = "rounded";

        public const string Sharp = "sharp";
    }
}
