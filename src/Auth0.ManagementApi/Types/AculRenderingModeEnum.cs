using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AculRenderingModeEnum.AculRenderingModeEnumSerializer))]
[Serializable]
public readonly record struct AculRenderingModeEnum : IStringEnum
{
    public static readonly AculRenderingModeEnum Advanced = new(Values.Advanced);

    public static readonly AculRenderingModeEnum Standard = new(Values.Standard);

    public AculRenderingModeEnum(string value)
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
    public static AculRenderingModeEnum FromCustom(string value)
    {
        return new AculRenderingModeEnum(value);
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

    public static bool operator ==(AculRenderingModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AculRenderingModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AculRenderingModeEnum value) => value.Value;

    public static explicit operator AculRenderingModeEnum(string value) => new(value);

    internal class AculRenderingModeEnumSerializer : JsonConverter<AculRenderingModeEnum>
    {
        public override AculRenderingModeEnum Read(
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
            return new AculRenderingModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculRenderingModeEnum value,
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
        public const string Advanced = "advanced";

        public const string Standard = "standard";
    }
}
