using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormComponentCategoryWidgetConst.FormComponentCategoryWidgetConstSerializer))]
[Serializable]
public readonly record struct FormComponentCategoryWidgetConst : IStringEnum
{
    public static readonly FormComponentCategoryWidgetConst Widget = new(Values.Widget);

    public FormComponentCategoryWidgetConst(string value)
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
    public static FormComponentCategoryWidgetConst FromCustom(string value)
    {
        return new FormComponentCategoryWidgetConst(value);
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

    public static bool operator ==(FormComponentCategoryWidgetConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormComponentCategoryWidgetConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormComponentCategoryWidgetConst value) => value.Value;

    public static explicit operator FormComponentCategoryWidgetConst(string value) => new(value);

    internal class FormComponentCategoryWidgetConstSerializer
        : JsonConverter<FormComponentCategoryWidgetConst>
    {
        public override FormComponentCategoryWidgetConst Read(
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
            return new FormComponentCategoryWidgetConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormComponentCategoryWidgetConst value,
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
        public const string Widget = "WIDGET";
    }
}
