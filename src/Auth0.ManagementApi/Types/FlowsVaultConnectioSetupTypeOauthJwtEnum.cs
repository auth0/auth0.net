using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectioSetupTypeOauthJwtEnum.FlowsVaultConnectioSetupTypeOauthJwtEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeOauthJwtEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeOauthJwtEnum OauthJwt = new(Values.OauthJwt);

    public FlowsVaultConnectioSetupTypeOauthJwtEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeOauthJwtEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeOauthJwtEnum(value);
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
        FlowsVaultConnectioSetupTypeOauthJwtEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectioSetupTypeOauthJwtEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeOauthJwtEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeOauthJwtEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectioSetupTypeOauthJwtEnumSerializer
        : JsonConverter<FlowsVaultConnectioSetupTypeOauthJwtEnum>
    {
        public override FlowsVaultConnectioSetupTypeOauthJwtEnum Read(
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
            return new FlowsVaultConnectioSetupTypeOauthJwtEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupTypeOauthJwtEnum value,
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
        public const string OauthJwt = "OAUTH_JWT";
    }
}
