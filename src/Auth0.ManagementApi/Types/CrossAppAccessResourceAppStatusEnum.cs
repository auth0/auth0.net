using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CrossAppAccessResourceAppStatusEnum.CrossAppAccessResourceAppStatusEnumSerializer)
)]
[Serializable]
public readonly record struct CrossAppAccessResourceAppStatusEnum : IStringEnum
{
    public static readonly CrossAppAccessResourceAppStatusEnum Enabled = new(Values.Enabled);

    public static readonly CrossAppAccessResourceAppStatusEnum Disabled = new(Values.Disabled);

    public CrossAppAccessResourceAppStatusEnum(string value)
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
    public static CrossAppAccessResourceAppStatusEnum FromCustom(string value)
    {
        return new CrossAppAccessResourceAppStatusEnum(value);
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

    public static bool operator ==(CrossAppAccessResourceAppStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CrossAppAccessResourceAppStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CrossAppAccessResourceAppStatusEnum value) =>
        value.Value;

    public static explicit operator CrossAppAccessResourceAppStatusEnum(string value) => new(value);

    internal class CrossAppAccessResourceAppStatusEnumSerializer
        : JsonConverter<CrossAppAccessResourceAppStatusEnum>
    {
        public override CrossAppAccessResourceAppStatusEnum Read(
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
            return new CrossAppAccessResourceAppStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CrossAppAccessResourceAppStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CrossAppAccessResourceAppStatusEnum ReadAsPropertyName(
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
            return new CrossAppAccessResourceAppStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CrossAppAccessResourceAppStatusEnum value,
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
