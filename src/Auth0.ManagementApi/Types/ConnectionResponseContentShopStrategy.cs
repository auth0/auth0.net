using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionResponseContentShopStrategy.ConnectionResponseContentShopStrategySerializer)
)]
[Serializable]
public readonly record struct ConnectionResponseContentShopStrategy : IStringEnum
{
    public static readonly ConnectionResponseContentShopStrategy Shop = new(Values.Shop);

    public ConnectionResponseContentShopStrategy(string value)
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
    public static ConnectionResponseContentShopStrategy FromCustom(string value)
    {
        return new ConnectionResponseContentShopStrategy(value);
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

    public static bool operator ==(ConnectionResponseContentShopStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionResponseContentShopStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionResponseContentShopStrategy value) =>
        value.Value;

    public static explicit operator ConnectionResponseContentShopStrategy(string value) =>
        new(value);

    internal class ConnectionResponseContentShopStrategySerializer
        : JsonConverter<ConnectionResponseContentShopStrategy>
    {
        public override ConnectionResponseContentShopStrategy Read(
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
            return new ConnectionResponseContentShopStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionResponseContentShopStrategy value,
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
        public const string Shop = "shop";
    }
}
