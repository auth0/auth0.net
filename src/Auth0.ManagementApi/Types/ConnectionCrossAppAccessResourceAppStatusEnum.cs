using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionCrossAppAccessResourceAppStatusEnum.ConnectionCrossAppAccessResourceAppStatusEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionCrossAppAccessResourceAppStatusEnum : IStringEnum
{
    public static readonly ConnectionCrossAppAccessResourceAppStatusEnum Disabled = new(
        Values.Disabled
    );

    public static readonly ConnectionCrossAppAccessResourceAppStatusEnum Enabled = new(
        Values.Enabled
    );

    public ConnectionCrossAppAccessResourceAppStatusEnum(string value)
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
    public static ConnectionCrossAppAccessResourceAppStatusEnum FromCustom(string value)
    {
        return new ConnectionCrossAppAccessResourceAppStatusEnum(value);
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
        ConnectionCrossAppAccessResourceAppStatusEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionCrossAppAccessResourceAppStatusEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionCrossAppAccessResourceAppStatusEnum value) =>
        value.Value;

    public static explicit operator ConnectionCrossAppAccessResourceAppStatusEnum(string value) =>
        new(value);

    internal class ConnectionCrossAppAccessResourceAppStatusEnumSerializer
        : JsonConverter<ConnectionCrossAppAccessResourceAppStatusEnum>
    {
        public override ConnectionCrossAppAccessResourceAppStatusEnum Read(
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
            return new ConnectionCrossAppAccessResourceAppStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionCrossAppAccessResourceAppStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionCrossAppAccessResourceAppStatusEnum ReadAsPropertyName(
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
            return new ConnectionCrossAppAccessResourceAppStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionCrossAppAccessResourceAppStatusEnum value,
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
        public const string Disabled = "disabled";

        public const string Enabled = "enabled";
    }
}
