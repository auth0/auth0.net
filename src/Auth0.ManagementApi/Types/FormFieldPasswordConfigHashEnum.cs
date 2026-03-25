using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldPasswordConfigHashEnum.FormFieldPasswordConfigHashEnumSerializer))]
[Serializable]
public readonly record struct FormFieldPasswordConfigHashEnum : IStringEnum
{
    public static readonly FormFieldPasswordConfigHashEnum None = new(Values.None);

    public static readonly FormFieldPasswordConfigHashEnum Md5 = new(Values.Md5);

    public static readonly FormFieldPasswordConfigHashEnum Sha1 = new(Values.Sha1);

    public static readonly FormFieldPasswordConfigHashEnum Sha256 = new(Values.Sha256);

    public static readonly FormFieldPasswordConfigHashEnum Sha512 = new(Values.Sha512);

    public FormFieldPasswordConfigHashEnum(string value)
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
    public static FormFieldPasswordConfigHashEnum FromCustom(string value)
    {
        return new FormFieldPasswordConfigHashEnum(value);
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

    public static bool operator ==(FormFieldPasswordConfigHashEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldPasswordConfigHashEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldPasswordConfigHashEnum value) => value.Value;

    public static explicit operator FormFieldPasswordConfigHashEnum(string value) => new(value);

    internal class FormFieldPasswordConfigHashEnumSerializer
        : JsonConverter<FormFieldPasswordConfigHashEnum>
    {
        public override FormFieldPasswordConfigHashEnum Read(
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
            return new FormFieldPasswordConfigHashEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldPasswordConfigHashEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldPasswordConfigHashEnum ReadAsPropertyName(
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
            return new FormFieldPasswordConfigHashEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldPasswordConfigHashEnum value,
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
        public const string None = "NONE";

        public const string Md5 = "MD5";

        public const string Sha1 = "SHA1";

        public const string Sha256 = "SHA256";

        public const string Sha512 = "SHA512";
    }
}
