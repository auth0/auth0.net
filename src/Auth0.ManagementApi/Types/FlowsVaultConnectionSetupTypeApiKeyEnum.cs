using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionSetupTypeApiKeyEnum.FlowsVaultConnectionSetupTypeApiKeyEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionSetupTypeApiKeyEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionSetupTypeApiKeyEnum ApiKey = new(Values.ApiKey);

    public FlowsVaultConnectionSetupTypeApiKeyEnum(string value)
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
    public static FlowsVaultConnectionSetupTypeApiKeyEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionSetupTypeApiKeyEnum(value);
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

    public static bool operator ==(FlowsVaultConnectionSetupTypeApiKeyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionSetupTypeApiKeyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionSetupTypeApiKeyEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionSetupTypeApiKeyEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionSetupTypeApiKeyEnumSerializer
        : JsonConverter<FlowsVaultConnectionSetupTypeApiKeyEnum>
    {
        public override FlowsVaultConnectionSetupTypeApiKeyEnum Read(
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
            return new FlowsVaultConnectionSetupTypeApiKeyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionSetupTypeApiKeyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowsVaultConnectionSetupTypeApiKeyEnum ReadAsPropertyName(
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
            return new FlowsVaultConnectionSetupTypeApiKeyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowsVaultConnectionSetupTypeApiKeyEnum value,
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
        public const string ApiKey = "API_KEY";
    }
}
