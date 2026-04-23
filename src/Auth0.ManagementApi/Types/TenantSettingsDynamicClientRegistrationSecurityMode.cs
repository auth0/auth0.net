using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(TenantSettingsDynamicClientRegistrationSecurityMode.TenantSettingsDynamicClientRegistrationSecurityModeSerializer)
)]
[Serializable]
public readonly record struct TenantSettingsDynamicClientRegistrationSecurityMode : IStringEnum
{
    public static readonly TenantSettingsDynamicClientRegistrationSecurityMode Strict = new(
        Values.Strict
    );

    public static readonly TenantSettingsDynamicClientRegistrationSecurityMode Permissive = new(
        Values.Permissive
    );

    public TenantSettingsDynamicClientRegistrationSecurityMode(string value)
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
    public static TenantSettingsDynamicClientRegistrationSecurityMode FromCustom(string value)
    {
        return new TenantSettingsDynamicClientRegistrationSecurityMode(value);
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
        TenantSettingsDynamicClientRegistrationSecurityMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TenantSettingsDynamicClientRegistrationSecurityMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TenantSettingsDynamicClientRegistrationSecurityMode value
    ) => value.Value;

    public static explicit operator TenantSettingsDynamicClientRegistrationSecurityMode(
        string value
    ) => new(value);

    internal class TenantSettingsDynamicClientRegistrationSecurityModeSerializer
        : JsonConverter<TenantSettingsDynamicClientRegistrationSecurityMode>
    {
        public override TenantSettingsDynamicClientRegistrationSecurityMode Read(
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
            return new TenantSettingsDynamicClientRegistrationSecurityMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TenantSettingsDynamicClientRegistrationSecurityMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TenantSettingsDynamicClientRegistrationSecurityMode ReadAsPropertyName(
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
            return new TenantSettingsDynamicClientRegistrationSecurityMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TenantSettingsDynamicClientRegistrationSecurityMode value,
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
        public const string Strict = "strict";

        public const string Permissive = "permissive";
    }
}
