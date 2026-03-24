using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionEmailEmailSyntax.ConnectionEmailEmailSyntaxSerializer))]
[Serializable]
public readonly record struct ConnectionEmailEmailSyntax : IStringEnum
{
    public static readonly ConnectionEmailEmailSyntax Liquid = new(Values.Liquid);

    public ConnectionEmailEmailSyntax(string value)
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
    public static ConnectionEmailEmailSyntax FromCustom(string value)
    {
        return new ConnectionEmailEmailSyntax(value);
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

    public static bool operator ==(ConnectionEmailEmailSyntax value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionEmailEmailSyntax value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionEmailEmailSyntax value) => value.Value;

    public static explicit operator ConnectionEmailEmailSyntax(string value) => new(value);

    internal class ConnectionEmailEmailSyntaxSerializer : JsonConverter<ConnectionEmailEmailSyntax>
    {
        public override ConnectionEmailEmailSyntax Read(
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
            return new ConnectionEmailEmailSyntax(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionEmailEmailSyntax value,
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
        public const string Liquid = "liquid";
    }
}
