using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(TenantSettingsDeviceFlowCharset.TenantSettingsDeviceFlowCharsetSerializer))]
[Serializable]
public readonly record struct TenantSettingsDeviceFlowCharset : IStringEnum
{
    public static readonly TenantSettingsDeviceFlowCharset Base20 = new(Values.Base20);

    public static readonly TenantSettingsDeviceFlowCharset Digits = new(Values.Digits);

    public TenantSettingsDeviceFlowCharset(string value)
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
    public static TenantSettingsDeviceFlowCharset FromCustom(string value)
    {
        return new TenantSettingsDeviceFlowCharset(value);
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

    public static bool operator ==(TenantSettingsDeviceFlowCharset value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenantSettingsDeviceFlowCharset value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenantSettingsDeviceFlowCharset value) => value.Value;

    public static explicit operator TenantSettingsDeviceFlowCharset(string value) => new(value);

    internal class TenantSettingsDeviceFlowCharsetSerializer
        : JsonConverter<TenantSettingsDeviceFlowCharset>
    {
        public override TenantSettingsDeviceFlowCharset Read(
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
            return new TenantSettingsDeviceFlowCharset(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TenantSettingsDeviceFlowCharset value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TenantSettingsDeviceFlowCharset ReadAsPropertyName(
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
            return new TenantSettingsDeviceFlowCharset(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TenantSettingsDeviceFlowCharset value,
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
        public const string Base20 = "base20";

        public const string Digits = "digits";
    }
}
