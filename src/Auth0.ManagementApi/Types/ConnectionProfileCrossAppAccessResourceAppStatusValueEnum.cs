using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionProfileCrossAppAccessResourceAppStatusValueEnum.ConnectionProfileCrossAppAccessResourceAppStatusValueEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionProfileCrossAppAccessResourceAppStatusValueEnum
    : IStringEnum
{
    public static readonly ConnectionProfileCrossAppAccessResourceAppStatusValueEnum Enabled = new(
        Values.Enabled
    );

    public static readonly ConnectionProfileCrossAppAccessResourceAppStatusValueEnum Disabled = new(
        Values.Disabled
    );

    public ConnectionProfileCrossAppAccessResourceAppStatusValueEnum(string value)
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
    public static ConnectionProfileCrossAppAccessResourceAppStatusValueEnum FromCustom(string value)
    {
        return new ConnectionProfileCrossAppAccessResourceAppStatusValueEnum(value);
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
        ConnectionProfileCrossAppAccessResourceAppStatusValueEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileCrossAppAccessResourceAppStatusValueEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionProfileCrossAppAccessResourceAppStatusValueEnum value
    ) => value.Value;

    public static explicit operator ConnectionProfileCrossAppAccessResourceAppStatusValueEnum(
        string value
    ) => new(value);

    internal class ConnectionProfileCrossAppAccessResourceAppStatusValueEnumSerializer
        : JsonConverter<ConnectionProfileCrossAppAccessResourceAppStatusValueEnum>
    {
        public override ConnectionProfileCrossAppAccessResourceAppStatusValueEnum Read(
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
            return new ConnectionProfileCrossAppAccessResourceAppStatusValueEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionProfileCrossAppAccessResourceAppStatusValueEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionProfileCrossAppAccessResourceAppStatusValueEnum ReadAsPropertyName(
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
            return new ConnectionProfileCrossAppAccessResourceAppStatusValueEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionProfileCrossAppAccessResourceAppStatusValueEnum value,
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
        public const string Enabled = "enabled";

        public const string Disabled = "disabled";
    }
}
