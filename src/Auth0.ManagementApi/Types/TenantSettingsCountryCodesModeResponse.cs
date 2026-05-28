using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(TenantSettingsCountryCodesModeResponse.TenantSettingsCountryCodesModeResponseSerializer)
)]
[Serializable]
public readonly record struct TenantSettingsCountryCodesModeResponse : IStringEnum
{
    public static readonly TenantSettingsCountryCodesModeResponse Allow = new(Values.Allow);

    public static readonly TenantSettingsCountryCodesModeResponse Deny = new(Values.Deny);

    public TenantSettingsCountryCodesModeResponse(string value)
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
    public static TenantSettingsCountryCodesModeResponse FromCustom(string value)
    {
        return new TenantSettingsCountryCodesModeResponse(value);
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

    public static bool operator ==(TenantSettingsCountryCodesModeResponse value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenantSettingsCountryCodesModeResponse value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenantSettingsCountryCodesModeResponse value) =>
        value.Value;

    public static explicit operator TenantSettingsCountryCodesModeResponse(string value) =>
        new(value);

    internal class TenantSettingsCountryCodesModeResponseSerializer
        : JsonConverter<TenantSettingsCountryCodesModeResponse>
    {
        public override TenantSettingsCountryCodesModeResponse Read(
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
            return new TenantSettingsCountryCodesModeResponse(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TenantSettingsCountryCodesModeResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TenantSettingsCountryCodesModeResponse ReadAsPropertyName(
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
            return new TenantSettingsCountryCodesModeResponse(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TenantSettingsCountryCodesModeResponse value,
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
