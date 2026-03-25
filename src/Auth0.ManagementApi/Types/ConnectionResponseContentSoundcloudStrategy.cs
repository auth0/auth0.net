using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentSoundcloudStrategy.ConnectionResponseContentSoundcloudStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentSoundcloudStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentSoundcloudStrategy Soundcloud = new(
        Values.Soundcloud
    );

    public ConnectionResponseContentSoundcloudStrategy(string value)
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
    public static ConnectionResponseContentSoundcloudStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentSoundcloudStrategy(value);
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
        ConnectionResponseContentSoundcloudStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentSoundcloudStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentSoundcloudStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentSoundcloudStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentSoundcloudStrategySerializer
        : JsonConverter<ConnectionResponseContentSoundcloudStrategy>
    {
        public override ConnectionResponseContentSoundcloudStrategy Read(
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
            return new ConnectionResponseContentSoundcloudStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentSoundcloudStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionResponseContentSoundcloudStrategy ReadAsPropertyName(
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
            return new ConnectionResponseContentSoundcloudStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionResponseContentSoundcloudStrategy value,
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
        public const string Soundcloud = "soundcloud";
    }
}
