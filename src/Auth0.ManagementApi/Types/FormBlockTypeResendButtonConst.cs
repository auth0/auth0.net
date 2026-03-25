using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormBlockTypeResendButtonConst.FormBlockTypeResendButtonConstSerializer))]
[Serializable]
public readonly record struct FormBlockTypeResendButtonConst : IStringEnum
{
    public static readonly FormBlockTypeResendButtonConst ResendButton = new(Values.ResendButton);

    public FormBlockTypeResendButtonConst(string value)
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
    public static FormBlockTypeResendButtonConst FromCustom(string value)
    {
        return new FormBlockTypeResendButtonConst(value);
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

    public static bool operator ==(FormBlockTypeResendButtonConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypeResendButtonConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypeResendButtonConst value) => value.Value;

    public static explicit operator FormBlockTypeResendButtonConst(string value) => new(value);

    internal class FormBlockTypeResendButtonConstSerializer
        : JsonConverter<FormBlockTypeResendButtonConst>
    {
        public override FormBlockTypeResendButtonConst Read(
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
            return new FormBlockTypeResendButtonConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormBlockTypeResendButtonConst value,
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
        public const string ResendButton = "RESEND_BUTTON";
    }
}
