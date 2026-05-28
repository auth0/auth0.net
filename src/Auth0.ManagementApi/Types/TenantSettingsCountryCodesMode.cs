using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(TenantSettingsCountryCodesMode.TenantSettingsCountryCodesModeSerializer))]
[Serializable]
public readonly record struct TenantSettingsCountryCodesMode : IStringEnum
{
    public static readonly TenantSettingsCountryCodesMode Allow = new(Values.Allow);

    public static readonly TenantSettingsCountryCodesMode Deny = new(Values.Deny);

    public TenantSettingsCountryCodesMode(string value)
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
    public static TenantSettingsCountryCodesMode FromCustom(string value)
    {
        return new TenantSettingsCountryCodesMode(value);
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

    public static bool operator ==(TenantSettingsCountryCodesMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenantSettingsCountryCodesMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenantSettingsCountryCodesMode value) => value.Value;

    public static explicit operator TenantSettingsCountryCodesMode(string value) => new(value);

    internal class TenantSettingsCountryCodesModeSerializer
        : JsonConverter<TenantSettingsCountryCodesMode>
    {
        public override TenantSettingsCountryCodesMode Read(
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
            return new TenantSettingsCountryCodesMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TenantSettingsCountryCodesMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TenantSettingsCountryCodesMode ReadAsPropertyName(
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
            return new TenantSettingsCountryCodesMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TenantSettingsCountryCodesMode value,
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
        public const string Allow = "allow";

        public const string Deny = "deny";
    }
}
