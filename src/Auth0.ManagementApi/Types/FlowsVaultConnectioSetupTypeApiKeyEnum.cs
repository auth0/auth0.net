using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectioSetupTypeApiKeyEnum.FlowsVaultConnectioSetupTypeApiKeyEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectioSetupTypeApiKeyEnum : IStringEnum
{
    public static readonly FlowsVaultConnectioSetupTypeApiKeyEnum ApiKey = new(Values.ApiKey);

    public FlowsVaultConnectioSetupTypeApiKeyEnum(string value)
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
    public static FlowsVaultConnectioSetupTypeApiKeyEnum FromCustom(string value)
    {
        return new FlowsVaultConnectioSetupTypeApiKeyEnum(value);
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

    public static bool operator ==(FlowsVaultConnectioSetupTypeApiKeyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectioSetupTypeApiKeyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectioSetupTypeApiKeyEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectioSetupTypeApiKeyEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectioSetupTypeApiKeyEnumSerializer
        : JsonConverter<FlowsVaultConnectioSetupTypeApiKeyEnum>
    {
        public override FlowsVaultConnectioSetupTypeApiKeyEnum Read(
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
            return new FlowsVaultConnectioSetupTypeApiKeyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectioSetupTypeApiKeyEnum value,
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
        public const string ApiKey = "API_KEY";
    }
}
