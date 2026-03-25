using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(TenantSettingsResourceParameterProfile.TenantSettingsResourceParameterProfileSerializer)
)]
[Serializable]
public readonly record struct TenantSettingsResourceParameterProfile : IStringEnum
{
    public static readonly TenantSettingsResourceParameterProfile Audience = new(Values.Audience);

    public static readonly TenantSettingsResourceParameterProfile Compatibility = new(
        Values.Compatibility
    );

    public TenantSettingsResourceParameterProfile(string value)
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
    public static TenantSettingsResourceParameterProfile FromCustom(string value)
    {
        return new TenantSettingsResourceParameterProfile(value);
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

    public static bool operator ==(TenantSettingsResourceParameterProfile value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenantSettingsResourceParameterProfile value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenantSettingsResourceParameterProfile value) =>
        value.Value;

    public static explicit operator TenantSettingsResourceParameterProfile(string value) =>
        new(value);

    internal class TenantSettingsResourceParameterProfileSerializer
        : JsonConverter<TenantSettingsResourceParameterProfile>
    {
        public override TenantSettingsResourceParameterProfile Read(
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
            return new TenantSettingsResourceParameterProfile(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TenantSettingsResourceParameterProfile value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TenantSettingsResourceParameterProfile ReadAsPropertyName(
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
            return new TenantSettingsResourceParameterProfile(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TenantSettingsResourceParameterProfile value,
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
        public const string Audience = "audience";

        public const string Compatibility = "compatibility";
    }
}
