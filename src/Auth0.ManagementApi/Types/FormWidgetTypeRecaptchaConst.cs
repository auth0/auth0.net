using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormWidgetTypeRecaptchaConst.FormWidgetTypeRecaptchaConstSerializer))]
[Serializable]
public readonly record struct FormWidgetTypeRecaptchaConst : IStringEnum
{
    public static readonly FormWidgetTypeRecaptchaConst Recaptcha = new(Values.Recaptcha);

    public FormWidgetTypeRecaptchaConst(string value)
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
    public static FormWidgetTypeRecaptchaConst FromCustom(string value)
    {
        return new FormWidgetTypeRecaptchaConst(value);
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

    public static bool operator ==(FormWidgetTypeRecaptchaConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormWidgetTypeRecaptchaConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormWidgetTypeRecaptchaConst value) => value.Value;

    public static explicit operator FormWidgetTypeRecaptchaConst(string value) => new(value);

    internal class FormWidgetTypeRecaptchaConstSerializer
        : JsonConverter<FormWidgetTypeRecaptchaConst>
    {
        public override FormWidgetTypeRecaptchaConst Read(
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
            return new FormWidgetTypeRecaptchaConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormWidgetTypeRecaptchaConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormWidgetTypeRecaptchaConst ReadAsPropertyName(
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
            return new FormWidgetTypeRecaptchaConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormWidgetTypeRecaptchaConst value,
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
        public const string Recaptcha = "RECAPTCHA";
    }
}
