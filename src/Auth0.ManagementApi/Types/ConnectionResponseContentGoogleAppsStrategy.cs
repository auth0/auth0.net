using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentGoogleAppsStrategy.ConnectionResponseContentGoogleAppsStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentGoogleAppsStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentGoogleAppsStrategy GoogleApps = new(
        Values.GoogleApps
    );

    public ConnectionResponseContentGoogleAppsStrategy(string value)
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
    public static ConnectionResponseContentGoogleAppsStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentGoogleAppsStrategy(value);
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
        ConnectionResponseContentGoogleAppsStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentGoogleAppsStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentGoogleAppsStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentGoogleAppsStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentGoogleAppsStrategySerializer
        : JsonConverter<ConnectionResponseContentGoogleAppsStrategy>
    {
        public override ConnectionResponseContentGoogleAppsStrategy Read(
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
            return new ConnectionResponseContentGoogleAppsStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentGoogleAppsStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GoogleApps = "google-apps";
    }
}
