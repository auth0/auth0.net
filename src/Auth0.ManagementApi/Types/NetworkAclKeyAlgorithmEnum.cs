using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(NetworkAclKeyAlgorithmEnum.NetworkAclKeyAlgorithmEnumSerializer))]
[Serializable]
public readonly record struct NetworkAclKeyAlgorithmEnum : IStringEnum
{
    public static readonly NetworkAclKeyAlgorithmEnum HmacSha256 = new(Values.HmacSha256);

    public NetworkAclKeyAlgorithmEnum(string value)
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
    public static NetworkAclKeyAlgorithmEnum FromCustom(string value)
    {
        return new NetworkAclKeyAlgorithmEnum(value);
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

    public static bool operator ==(NetworkAclKeyAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NetworkAclKeyAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NetworkAclKeyAlgorithmEnum value) => value.Value;

    public static explicit operator NetworkAclKeyAlgorithmEnum(string value) => new(value);

    internal class NetworkAclKeyAlgorithmEnumSerializer : JsonConverter<NetworkAclKeyAlgorithmEnum>
    {
        public override NetworkAclKeyAlgorithmEnum Read(
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
            return new NetworkAclKeyAlgorithmEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NetworkAclKeyAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NetworkAclKeyAlgorithmEnum ReadAsPropertyName(
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
            return new NetworkAclKeyAlgorithmEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NetworkAclKeyAlgorithmEnum value,
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
        public const string HmacSha256 = "hmac-sha256";
    }
}
