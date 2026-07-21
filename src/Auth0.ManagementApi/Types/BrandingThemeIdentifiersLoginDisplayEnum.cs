using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BrandingThemeIdentifiersLoginDisplayEnum.BrandingThemeIdentifiersLoginDisplayEnumSerializer)
)]
[Serializable]
public readonly record struct BrandingThemeIdentifiersLoginDisplayEnum : IStringEnum
{
    public static readonly BrandingThemeIdentifiersLoginDisplayEnum Separate = new(Values.Separate);

    public static readonly BrandingThemeIdentifiersLoginDisplayEnum Unified = new(Values.Unified);

    public BrandingThemeIdentifiersLoginDisplayEnum(string value)
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
    public static BrandingThemeIdentifiersLoginDisplayEnum FromCustom(string value)
    {
        return new BrandingThemeIdentifiersLoginDisplayEnum(value);
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
        BrandingThemeIdentifiersLoginDisplayEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BrandingThemeIdentifiersLoginDisplayEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BrandingThemeIdentifiersLoginDisplayEnum value) =>
        value.Value;

    public static explicit operator BrandingThemeIdentifiersLoginDisplayEnum(string value) =>
        new(value);

    internal class BrandingThemeIdentifiersLoginDisplayEnumSerializer
        : JsonConverter<BrandingThemeIdentifiersLoginDisplayEnum>
    {
        public override BrandingThemeIdentifiersLoginDisplayEnum Read(
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
            return new BrandingThemeIdentifiersLoginDisplayEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersLoginDisplayEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandingThemeIdentifiersLoginDisplayEnum ReadAsPropertyName(
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
            return new BrandingThemeIdentifiersLoginDisplayEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingThemeIdentifiersLoginDisplayEnum value,
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
        public const string Separate = "separate";

        public const string Unified = "unified";
    }
}
