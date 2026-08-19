using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum.ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum
    : IStringEnum
{
    public static readonly ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum Enabled =
        new(Values.Enabled);

    public static readonly ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum Disabled =
        new(Values.Disabled);

    public ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum(string value)
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
    public static ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum FromCustom(
        string value
    )
    {
        return new ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum(value);
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
        ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum value
    ) => value.Value;

    public static explicit operator ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum(
        string value
    ) => new(value);

    internal class ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnumSerializer
        : JsonConverter<ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum>
    {
        public override ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum Read(
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
            return new ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum ReadAsPropertyName(
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
            return new ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum value,
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
