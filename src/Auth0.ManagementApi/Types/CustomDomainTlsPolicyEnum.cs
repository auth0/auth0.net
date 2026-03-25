using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomDomainTlsPolicyEnum.CustomDomainTlsPolicyEnumSerializer))]
[Serializable]
public readonly record struct CustomDomainTlsPolicyEnum : IStringEnum
{
    public static readonly CustomDomainTlsPolicyEnum Recommended = new(Values.Recommended);

    public CustomDomainTlsPolicyEnum(string value)
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
    public static CustomDomainTlsPolicyEnum FromCustom(string value)
    {
        return new CustomDomainTlsPolicyEnum(value);
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

    public static bool operator ==(CustomDomainTlsPolicyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainTlsPolicyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainTlsPolicyEnum value) => value.Value;

    public static explicit operator CustomDomainTlsPolicyEnum(string value) => new(value);

    internal class CustomDomainTlsPolicyEnumSerializer : JsonConverter<CustomDomainTlsPolicyEnum>
    {
        public override CustomDomainTlsPolicyEnum Read(
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
            return new CustomDomainTlsPolicyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomDomainTlsPolicyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomDomainTlsPolicyEnum ReadAsPropertyName(
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
            return new CustomDomainTlsPolicyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomDomainTlsPolicyEnum value,
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
        public const string Recommended = "recommended";
    }
}
