using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormBlockResendButtonConfigTextAlignmentEnum.FormBlockResendButtonConfigTextAlignmentEnumSerializer)
)]
[Serializable]
public readonly record struct FormBlockResendButtonConfigTextAlignmentEnum : IStringEnum
{
    public static readonly FormBlockResendButtonConfigTextAlignmentEnum Left = new(Values.Left);

    public static readonly FormBlockResendButtonConfigTextAlignmentEnum Center = new(Values.Center);

    public static readonly FormBlockResendButtonConfigTextAlignmentEnum Right = new(Values.Right);

    public FormBlockResendButtonConfigTextAlignmentEnum(string value)
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
    public static FormBlockResendButtonConfigTextAlignmentEnum FromCustom(string value)
    {
        return new FormBlockResendButtonConfigTextAlignmentEnum(value);
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
        FormBlockResendButtonConfigTextAlignmentEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FormBlockResendButtonConfigTextAlignmentEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockResendButtonConfigTextAlignmentEnum value) =>
        value.Value;

    public static explicit operator FormBlockResendButtonConfigTextAlignmentEnum(string value) =>
        new(value);

    internal class FormBlockResendButtonConfigTextAlignmentEnumSerializer
        : JsonConverter<FormBlockResendButtonConfigTextAlignmentEnum>
    {
        public override FormBlockResendButtonConfigTextAlignmentEnum Read(
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
            return new FormBlockResendButtonConfigTextAlignmentEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormBlockResendButtonConfigTextAlignmentEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormBlockResendButtonConfigTextAlignmentEnum ReadAsPropertyName(
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
            return new FormBlockResendButtonConfigTextAlignmentEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormBlockResendButtonConfigTextAlignmentEnum value,
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
        public const string Left = "LEFT";

        public const string Center = "CENTER";

        public const string Right = "RIGHT";
    }
}
