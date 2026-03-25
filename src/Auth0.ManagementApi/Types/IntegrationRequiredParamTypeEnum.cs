using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(IntegrationRequiredParamTypeEnum.IntegrationRequiredParamTypeEnumSerializer))]
[Serializable]
public readonly record struct IntegrationRequiredParamTypeEnum : IStringEnum
{
    public static readonly IntegrationRequiredParamTypeEnum Unspecified = new(Values.Unspecified);

    public static readonly IntegrationRequiredParamTypeEnum String = new(Values.String);

    public IntegrationRequiredParamTypeEnum(string value)
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
    public static IntegrationRequiredParamTypeEnum FromCustom(string value)
    {
        return new IntegrationRequiredParamTypeEnum(value);
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

    public static bool operator ==(IntegrationRequiredParamTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IntegrationRequiredParamTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IntegrationRequiredParamTypeEnum value) => value.Value;

    public static explicit operator IntegrationRequiredParamTypeEnum(string value) => new(value);

    internal class IntegrationRequiredParamTypeEnumSerializer
        : JsonConverter<IntegrationRequiredParamTypeEnum>
    {
        public override IntegrationRequiredParamTypeEnum Read(
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
            return new IntegrationRequiredParamTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IntegrationRequiredParamTypeEnum value,
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
        public const string Unspecified = "UNSPECIFIED";

        public const string String = "STRING";
    }
}
