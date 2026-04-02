using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldDateConfigFormatEnum.FormFieldDateConfigFormatEnumSerializer))]
[Serializable]
public readonly record struct FormFieldDateConfigFormatEnum : IStringEnum
{
    public static readonly FormFieldDateConfigFormatEnum Date = new(Values.Date);

    public static readonly FormFieldDateConfigFormatEnum Time = new(Values.Time);

    public FormFieldDateConfigFormatEnum(string value)
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
    public static FormFieldDateConfigFormatEnum FromCustom(string value)
    {
        return new FormFieldDateConfigFormatEnum(value);
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

    public static bool operator ==(FormFieldDateConfigFormatEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldDateConfigFormatEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldDateConfigFormatEnum value) => value.Value;

    public static explicit operator FormFieldDateConfigFormatEnum(string value) => new(value);

    internal class FormFieldDateConfigFormatEnumSerializer
        : JsonConverter<FormFieldDateConfigFormatEnum>
    {
        public override FormFieldDateConfigFormatEnum Read(
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
            return new FormFieldDateConfigFormatEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldDateConfigFormatEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldDateConfigFormatEnum ReadAsPropertyName(
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
            return new FormFieldDateConfigFormatEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldDateConfigFormatEnum value,
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
        public const string Date = "DATE";

        public const string Time = "TIME";
    }
}
