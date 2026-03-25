using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionDigestAlgorithmEnumSaml.ConnectionDigestAlgorithmEnumSamlSerializer)
)]
[Serializable]
public readonly record struct ConnectionDigestAlgorithmEnumSaml : IStringEnum
{
    public static readonly ConnectionDigestAlgorithmEnumSaml Sha1 = new(Values.Sha1);

    public static readonly ConnectionDigestAlgorithmEnumSaml Sha256 = new(Values.Sha256);

    public ConnectionDigestAlgorithmEnumSaml(string value)
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
    public static ConnectionDigestAlgorithmEnumSaml FromCustom(string value)
    {
        return new ConnectionDigestAlgorithmEnumSaml(value);
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

    public static bool operator ==(ConnectionDigestAlgorithmEnumSaml value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionDigestAlgorithmEnumSaml value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionDigestAlgorithmEnumSaml value) => value.Value;

    public static explicit operator ConnectionDigestAlgorithmEnumSaml(string value) => new(value);

    internal class ConnectionDigestAlgorithmEnumSamlSerializer
        : JsonConverter<ConnectionDigestAlgorithmEnumSaml>
    {
        public override ConnectionDigestAlgorithmEnumSaml Read(
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
            return new ConnectionDigestAlgorithmEnumSaml(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionDigestAlgorithmEnumSaml value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionDigestAlgorithmEnumSaml ReadAsPropertyName(
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
            return new ConnectionDigestAlgorithmEnumSaml(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionDigestAlgorithmEnumSaml value,
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
        public const string Sha1 = "sha1";

        public const string Sha256 = "sha256";
    }
}
