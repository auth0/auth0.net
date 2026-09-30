using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FeatureFlagConfigParamTypeEnum.FeatureFlagConfigParamTypeEnumSerializer))]
[Serializable]
public readonly record struct FeatureFlagConfigParamTypeEnum : IStringEnum
{
    public static readonly FeatureFlagConfigParamTypeEnum String = new(Values.String);

    public static readonly FeatureFlagConfigParamTypeEnum Boolean = new(Values.Boolean);

    public static readonly FeatureFlagConfigParamTypeEnum Number = new(Values.Number);

    public static readonly FeatureFlagConfigParamTypeEnum Array = new(Values.Array);

    public static readonly FeatureFlagConfigParamTypeEnum Object = new(Values.Object);

    public FeatureFlagConfigParamTypeEnum(string value)
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
    public static FeatureFlagConfigParamTypeEnum FromCustom(string value)
    {
        return new FeatureFlagConfigParamTypeEnum(value);
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

    public static bool operator ==(FeatureFlagConfigParamTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeatureFlagConfigParamTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeatureFlagConfigParamTypeEnum value) => value.Value;

    public static explicit operator FeatureFlagConfigParamTypeEnum(string value) => new(value);

    internal class FeatureFlagConfigParamTypeEnumSerializer
        : JsonConverter<FeatureFlagConfigParamTypeEnum>
    {
        public override FeatureFlagConfigParamTypeEnum Read(
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
            return new FeatureFlagConfigParamTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeatureFlagConfigParamTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FeatureFlagConfigParamTypeEnum ReadAsPropertyName(
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
            return new FeatureFlagConfigParamTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FeatureFlagConfigParamTypeEnum value,
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
        public const string String = "string";

        public const string Boolean = "boolean";

        public const string Number = "number";

        public const string Array = "array";

        public const string Object = "object";
    }
}
