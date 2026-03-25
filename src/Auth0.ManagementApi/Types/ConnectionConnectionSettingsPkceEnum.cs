using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionConnectionSettingsPkceEnum.ConnectionConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionConnectionSettingsPkceEnum : IStringEnum
{
    public static readonly ConnectionConnectionSettingsPkceEnum Auto = new(Values.Auto);

    public static readonly ConnectionConnectionSettingsPkceEnum S256 = new(Values.S256);

    public static readonly ConnectionConnectionSettingsPkceEnum Plain = new(Values.Plain);

    public static readonly ConnectionConnectionSettingsPkceEnum Disabled = new(Values.Disabled);

    public ConnectionConnectionSettingsPkceEnum(string value)
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
    public static ConnectionConnectionSettingsPkceEnum FromCustom(string value)
    {
        return new ConnectionConnectionSettingsPkceEnum(value);
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

    public static bool operator ==(ConnectionConnectionSettingsPkceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionConnectionSettingsPkceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionConnectionSettingsPkceEnum value) =>
        value.Value;

    public static explicit operator ConnectionConnectionSettingsPkceEnum(string value) =>
        new(value);

    internal class ConnectionConnectionSettingsPkceEnumSerializer
        : JsonConverter<ConnectionConnectionSettingsPkceEnum>
    {
        public override ConnectionConnectionSettingsPkceEnum Read(
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
            return new ConnectionConnectionSettingsPkceEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new ConnectionConnectionSettingsPkceEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionConnectionSettingsPkceEnum value,
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
        public const string Auto = "auto";

        public const string S256 = "S256";

        public const string Plain = "plain";

        public const string Disabled = "disabled";
    }
}
