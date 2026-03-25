using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldTypeTextConst.FormFieldTypeTextConstSerializer))]
[Serializable]
public readonly record struct FormFieldTypeTextConst : IStringEnum
{
    public static readonly FormFieldTypeTextConst Text = new(Values.Text);

    public FormFieldTypeTextConst(string value)
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
    public static FormFieldTypeTextConst FromCustom(string value)
    {
        return new FormFieldTypeTextConst(value);
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

    public static bool operator ==(FormFieldTypeTextConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldTypeTextConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldTypeTextConst value) => value.Value;

    public static explicit operator FormFieldTypeTextConst(string value) => new(value);

    internal class FormFieldTypeTextConstSerializer : JsonConverter<FormFieldTypeTextConst>
    {
        public override FormFieldTypeTextConst Read(
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
            return new FormFieldTypeTextConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldTypeTextConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Text = "TEXT";
    }
}
