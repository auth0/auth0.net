using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(IntegrationFeatureTypeEnum.IntegrationFeatureTypeEnumSerializer))]
[Serializable]
public readonly record struct IntegrationFeatureTypeEnum : IStringEnum
{
    public static readonly IntegrationFeatureTypeEnum Unspecified = new(Values.Unspecified);

    public static readonly IntegrationFeatureTypeEnum Action = new(Values.Action);

    public static readonly IntegrationFeatureTypeEnum SocialConnection = new(
        Values.SocialConnection
    );

    public static readonly IntegrationFeatureTypeEnum LogStream = new(Values.LogStream);

    public static readonly IntegrationFeatureTypeEnum SsoIntegration = new(Values.SsoIntegration);

    public static readonly IntegrationFeatureTypeEnum SmsProvider = new(Values.SmsProvider);

    public IntegrationFeatureTypeEnum(string value)
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
    public static IntegrationFeatureTypeEnum FromCustom(string value)
    {
        return new IntegrationFeatureTypeEnum(value);
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

    public static bool operator ==(IntegrationFeatureTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IntegrationFeatureTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IntegrationFeatureTypeEnum value) => value.Value;

    public static explicit operator IntegrationFeatureTypeEnum(string value) => new(value);

    internal class IntegrationFeatureTypeEnumSerializer : JsonConverter<IntegrationFeatureTypeEnum>
    {
        public override IntegrationFeatureTypeEnum Read(
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
            return new IntegrationFeatureTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IntegrationFeatureTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IntegrationFeatureTypeEnum ReadAsPropertyName(
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
            return new IntegrationFeatureTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IntegrationFeatureTypeEnum value,
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
        public const string Unspecified = "unspecified";

        public const string Action = "action";

        public const string SocialConnection = "social_connection";

        public const string LogStream = "log_stream";

        public const string SsoIntegration = "sso_integration";

        public const string SmsProvider = "sms_provider";
    }
}
