using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CspFlag.CspFlagSerializer))]
[Serializable]
public readonly record struct CspFlag : IStringEnum
{
    public static readonly CspFlag UpgradeInsecureRequests = new(Values.UpgradeInsecureRequests);

    public static readonly CspFlag BlockAllMixedContent = new(Values.BlockAllMixedContent);

    public CspFlag(string value)
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
    public static CspFlag FromCustom(string value)
    {
        return new CspFlag(value);
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

    public static bool operator ==(CspFlag value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CspFlag value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CspFlag value) => value.Value;

    public static explicit operator CspFlag(string value) => new(value);

    internal class CspFlagSerializer : JsonConverter<CspFlag>
    {
        public override CspFlag Read(
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
            return new CspFlag(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CspFlag value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CspFlag ReadAsPropertyName(
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
            return new CspFlag(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CspFlag value,
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
        public const string UpgradeInsecureRequests = "upgrade-insecure-requests";

        public const string BlockAllMixedContent = "block-all-mixed-content";
    }
}
