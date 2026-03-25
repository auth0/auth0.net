using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormFieldFileConfigStorageTypeEnum.FormFieldFileConfigStorageTypeEnumSerializer)
)]
[Serializable]
public readonly record struct FormFieldFileConfigStorageTypeEnum : IStringEnum
{
    public static readonly FormFieldFileConfigStorageTypeEnum Managed = new(Values.Managed);

    public static readonly FormFieldFileConfigStorageTypeEnum Custom = new(Values.Custom);

    public FormFieldFileConfigStorageTypeEnum(string value)
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
    public static FormFieldFileConfigStorageTypeEnum FromCustom(string value)
    {
        return new FormFieldFileConfigStorageTypeEnum(value);
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

    public static bool operator ==(FormFieldFileConfigStorageTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldFileConfigStorageTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldFileConfigStorageTypeEnum value) => value.Value;

    public static explicit operator FormFieldFileConfigStorageTypeEnum(string value) => new(value);

    internal class FormFieldFileConfigStorageTypeEnumSerializer
        : JsonConverter<FormFieldFileConfigStorageTypeEnum>
    {
        public override FormFieldFileConfigStorageTypeEnum Read(
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
            return new FormFieldFileConfigStorageTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldFileConfigStorageTypeEnum value,
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
        public const string Managed = "MANAGED";

        public const string Custom = "CUSTOM";
    }
}
