using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionDeletionBehaviorEnum.ConnectionDeletionBehaviorEnumSerializer))]
[Serializable]
public readonly record struct ConnectionDeletionBehaviorEnum : IStringEnum
{
    public static readonly ConnectionDeletionBehaviorEnum Allow = new(Values.Allow);

    public static readonly ConnectionDeletionBehaviorEnum AllowIfEmpty = new(Values.AllowIfEmpty);

    public ConnectionDeletionBehaviorEnum(string value)
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
    public static ConnectionDeletionBehaviorEnum FromCustom(string value)
    {
        return new ConnectionDeletionBehaviorEnum(value);
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

    public static bool operator ==(ConnectionDeletionBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionDeletionBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionDeletionBehaviorEnum value) => value.Value;

    public static explicit operator ConnectionDeletionBehaviorEnum(string value) => new(value);

    internal class ConnectionDeletionBehaviorEnumSerializer
        : JsonConverter<ConnectionDeletionBehaviorEnum>
    {
        public override ConnectionDeletionBehaviorEnum Read(
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
            return new ConnectionDeletionBehaviorEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionDeletionBehaviorEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionDeletionBehaviorEnum ReadAsPropertyName(
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
            return new ConnectionDeletionBehaviorEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionDeletionBehaviorEnum value,
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
        public const string Allow = "allow";

        public const string AllowIfEmpty = "allow_if_empty";
    }
}
