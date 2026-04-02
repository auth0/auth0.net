using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldFileConfigCategoryEnum.FormFieldFileConfigCategoryEnumSerializer))]
[Serializable]
public readonly record struct FormFieldFileConfigCategoryEnum : IStringEnum
{
    public static readonly FormFieldFileConfigCategoryEnum Audio = new(Values.Audio);

    public static readonly FormFieldFileConfigCategoryEnum Video = new(Values.Video);

    public static readonly FormFieldFileConfigCategoryEnum Image = new(Values.Image);

    public static readonly FormFieldFileConfigCategoryEnum Document = new(Values.Document);

    public static readonly FormFieldFileConfigCategoryEnum Archive = new(Values.Archive);

    public FormFieldFileConfigCategoryEnum(string value)
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
    public static FormFieldFileConfigCategoryEnum FromCustom(string value)
    {
        return new FormFieldFileConfigCategoryEnum(value);
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

    public static bool operator ==(FormFieldFileConfigCategoryEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldFileConfigCategoryEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldFileConfigCategoryEnum value) => value.Value;

    public static explicit operator FormFieldFileConfigCategoryEnum(string value) => new(value);

    internal class FormFieldFileConfigCategoryEnumSerializer
        : JsonConverter<FormFieldFileConfigCategoryEnum>
    {
        public override FormFieldFileConfigCategoryEnum Read(
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
            return new FormFieldFileConfigCategoryEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldFileConfigCategoryEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldFileConfigCategoryEnum ReadAsPropertyName(
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
            return new FormFieldFileConfigCategoryEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldFileConfigCategoryEnum value,
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
        public const string Audio = "AUDIO";

        public const string Video = "VIDEO";

        public const string Image = "IMAGE";

        public const string Document = "DOCUMENT";

        public const string Archive = "ARCHIVE";
    }
}
