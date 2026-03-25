using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionSetupTypeBasicAuthEnum.FlowsVaultConnectionSetupTypeBasicAuthEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionSetupTypeBasicAuthEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionSetupTypeBasicAuthEnum BasicAuth = new(
        Values.BasicAuth
    );

    public FlowsVaultConnectionSetupTypeBasicAuthEnum(string value)
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
    public static FlowsVaultConnectionSetupTypeBasicAuthEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionSetupTypeBasicAuthEnum(value);
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
        FlowsVaultConnectionSetupTypeBasicAuthEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectionSetupTypeBasicAuthEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionSetupTypeBasicAuthEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionSetupTypeBasicAuthEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionSetupTypeBasicAuthEnumSerializer
        : JsonConverter<FlowsVaultConnectionSetupTypeBasicAuthEnum>
    {
        public override FlowsVaultConnectionSetupTypeBasicAuthEnum Read(
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
            return new FlowsVaultConnectionSetupTypeBasicAuthEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionSetupTypeBasicAuthEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowsVaultConnectionSetupTypeBasicAuthEnum ReadAsPropertyName(
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
            return new FlowsVaultConnectionSetupTypeBasicAuthEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowsVaultConnectionSetupTypeBasicAuthEnum value,
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
        public const string BasicAuth = "BASIC_AUTH";
    }
}
