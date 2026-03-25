using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentOffice365Strategy.ConnectionResponseContentOffice365StrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentOffice365Strategy : IStringEnum
{
    public static readonly ConnectionResponseContentOffice365Strategy Office365 = new(
        Values.Office365
    );

    public ConnectionResponseContentOffice365Strategy(string value)
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
    public static ConnectionResponseContentOffice365Strategy FromCustom(string value)
    {
        return new ConnectionResponseContentOffice365Strategy(value);
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
        ConnectionResponseContentOffice365Strategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionResponseContentOffice365Strategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentOffice365Strategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentOffice365Strategy(string value) =>
        new(value);

    internal class ConnectionResponseContentOffice365StrategySerializer
        : JsonConverter<ConnectionResponseContentOffice365Strategy>
    {
        public override ConnectionResponseContentOffice365Strategy Read(
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
            return new ConnectionResponseContentOffice365Strategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentOffice365Strategy value,
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
        public const string Office365 = "office365";
    }
}
