using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CspPolicyMode.CspPolicyModeSerializer))]
[Serializable]
public readonly record struct CspPolicyMode : IStringEnum
{
    public static readonly CspPolicyMode Enforcing = new(Values.Enforcing);

    public static readonly CspPolicyMode Reporting = new(Values.Reporting);

    public CspPolicyMode(string value)
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
    public static CspPolicyMode FromCustom(string value)
    {
        return new CspPolicyMode(value);
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

    public static bool operator ==(CspPolicyMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CspPolicyMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CspPolicyMode value) => value.Value;

    public static explicit operator CspPolicyMode(string value) => new(value);

    internal class CspPolicyModeSerializer : JsonConverter<CspPolicyMode>
    {
        public override CspPolicyMode Read(
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
            return new CspPolicyMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CspPolicyMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CspPolicyMode ReadAsPropertyName(
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
            return new CspPolicyMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CspPolicyMode value,
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
        public const string Enforcing = "enforcing";

        public const string Reporting = "reporting";
    }
}
