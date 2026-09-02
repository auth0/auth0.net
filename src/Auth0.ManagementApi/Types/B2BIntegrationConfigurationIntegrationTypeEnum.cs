using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(B2BIntegrationConfigurationIntegrationTypeEnum.B2BIntegrationConfigurationIntegrationTypeEnumSerializer)
)]
[Serializable]
public readonly record struct B2BIntegrationConfigurationIntegrationTypeEnum : IStringEnum
{
    public static readonly B2BIntegrationConfigurationIntegrationTypeEnum CustomAuthServer = new(
        Values.CustomAuthServer
    );

    public static readonly B2BIntegrationConfigurationIntegrationTypeEnum ThirdParty = new(
        Values.ThirdParty
    );

    public static readonly B2BIntegrationConfigurationIntegrationTypeEnum Application = new(
        Values.Application
    );

    public B2BIntegrationConfigurationIntegrationTypeEnum(string value)
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
    public static B2BIntegrationConfigurationIntegrationTypeEnum FromCustom(string value)
    {
        return new B2BIntegrationConfigurationIntegrationTypeEnum(value);
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
        B2BIntegrationConfigurationIntegrationTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        B2BIntegrationConfigurationIntegrationTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(B2BIntegrationConfigurationIntegrationTypeEnum value) =>
        value.Value;

    public static explicit operator B2BIntegrationConfigurationIntegrationTypeEnum(string value) =>
        new(value);

    internal class B2BIntegrationConfigurationIntegrationTypeEnumSerializer
        : JsonConverter<B2BIntegrationConfigurationIntegrationTypeEnum>
    {
        public override B2BIntegrationConfigurationIntegrationTypeEnum Read(
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
            return new B2BIntegrationConfigurationIntegrationTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            B2BIntegrationConfigurationIntegrationTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override B2BIntegrationConfigurationIntegrationTypeEnum ReadAsPropertyName(
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
            return new B2BIntegrationConfigurationIntegrationTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            B2BIntegrationConfigurationIntegrationTypeEnum value,
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
        public const string CustomAuthServer = "custom_auth_server";

        public const string ThirdParty = "third_party";

        public const string Application = "application";
    }
}
