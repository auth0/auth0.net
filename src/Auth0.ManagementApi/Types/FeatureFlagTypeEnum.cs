using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FeatureFlagTypeEnum.FeatureFlagTypeEnumSerializer))]
[Serializable]
public readonly record struct FeatureFlagTypeEnum : IStringEnum
{
    public static readonly FeatureFlagTypeEnum Auth0 = new(Values.Auth0);

    public static readonly FeatureFlagTypeEnum Self = new(Values.Self);

    public FeatureFlagTypeEnum(string value)
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
    public static FeatureFlagTypeEnum FromCustom(string value)
    {
        return new FeatureFlagTypeEnum(value);
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

    public static bool operator ==(FeatureFlagTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeatureFlagTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeatureFlagTypeEnum value) => value.Value;

    public static explicit operator FeatureFlagTypeEnum(string value) => new(value);

    internal class FeatureFlagTypeEnumSerializer : JsonConverter<FeatureFlagTypeEnum>
    {
        public override FeatureFlagTypeEnum Read(
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
            return new FeatureFlagTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeatureFlagTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FeatureFlagTypeEnum ReadAsPropertyName(
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
            return new FeatureFlagTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FeatureFlagTypeEnum value,
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
        public const string Auth0 = "auth0";

        public const string Self = "self";
    }
}
