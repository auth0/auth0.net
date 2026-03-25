using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionUseridAttributeEnumAzureAd.ConnectionUseridAttributeEnumAzureAdSerializer)
)]
[Serializable]
public readonly record struct ConnectionUseridAttributeEnumAzureAd : IStringEnum
{
    public static readonly ConnectionUseridAttributeEnumAzureAd Oid = new(Values.Oid);

    public static readonly ConnectionUseridAttributeEnumAzureAd Sub = new(Values.Sub);

    public ConnectionUseridAttributeEnumAzureAd(string value)
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
    public static ConnectionUseridAttributeEnumAzureAd FromCustom(string value)
    {
        return new ConnectionUseridAttributeEnumAzureAd(value);
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

    public static bool operator ==(ConnectionUseridAttributeEnumAzureAd value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionUseridAttributeEnumAzureAd value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionUseridAttributeEnumAzureAd value) =>
        value.Value;

    public static explicit operator ConnectionUseridAttributeEnumAzureAd(string value) =>
        new(value);

    internal class ConnectionUseridAttributeEnumAzureAdSerializer
        : JsonConverter<ConnectionUseridAttributeEnumAzureAd>
    {
        public override ConnectionUseridAttributeEnumAzureAd Read(
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
            return new ConnectionUseridAttributeEnumAzureAd(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionUseridAttributeEnumAzureAd value,
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
        public const string Oid = "oid";

        public const string Sub = "sub";
    }
}
