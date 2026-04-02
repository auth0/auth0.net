using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectioSetupTypeOauthAppEnum.FlowsVaultConnectioSetupTypeOauthAppEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeOauthAppEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeOauthAppEnum OauthApp = new(Values.OauthApp);

    public FlowsVaultConnectioSetupTypeOauthAppEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeOauthAppEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeOauthAppEnum(value);
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
        FlowsVaultConnectioSetupTypeOauthAppEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectioSetupTypeOauthAppEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeOauthAppEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeOauthAppEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectioSetupTypeOauthAppEnumSerializer
        : JsonConverter<FlowsVaultConnectioSetupTypeOauthAppEnum>
    {
        public override FlowsVaultConnectioSetupTypeOauthAppEnum Read(
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
            return new FlowsVaultConnectioSetupTypeOauthAppEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupTypeOauthAppEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowsVaultConnectioSetupTypeOauthAppEnum ReadAsPropertyName(
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
            return new FlowsVaultConnectioSetupTypeOauthAppEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupTypeOauthAppEnum value,
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
        public const string OauthApp = "OAUTH_APP";
    }
}
