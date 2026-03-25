using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PasswordCharacterTypeEnum.PasswordCharacterTypeEnumSerializer))]
[Serializable]
public readonly record struct PasswordCharacterTypeEnum : IStringEnum
{
    public static readonly PasswordCharacterTypeEnum Uppercase = new(Values.Uppercase);

    public static readonly PasswordCharacterTypeEnum Lowercase = new(Values.Lowercase);

    public static readonly PasswordCharacterTypeEnum Number = new(Values.Number);

    public static readonly PasswordCharacterTypeEnum Special = new(Values.Special);

    public PasswordCharacterTypeEnum(string value)
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
    public static PasswordCharacterTypeEnum FromCustom(string value)
    {
        return new PasswordCharacterTypeEnum(value);
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

    public static bool operator ==(PasswordCharacterTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PasswordCharacterTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PasswordCharacterTypeEnum value) => value.Value;

    public static explicit operator PasswordCharacterTypeEnum(string value) => new(value);

    internal class PasswordCharacterTypeEnumSerializer : JsonConverter<PasswordCharacterTypeEnum>
    {
        public override PasswordCharacterTypeEnum Read(
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
            return new PasswordCharacterTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PasswordCharacterTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PasswordCharacterTypeEnum ReadAsPropertyName(
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
            return new PasswordCharacterTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PasswordCharacterTypeEnum value,
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
        public const string Uppercase = "uppercase";

        public const string Lowercase = "lowercase";

        public const string Number = "number";

        public const string Special = "special";
    }
}
