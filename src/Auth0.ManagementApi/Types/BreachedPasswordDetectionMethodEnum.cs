using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(BreachedPasswordDetectionMethodEnum.BreachedPasswordDetectionMethodEnumSerializer)
)]
[Serializable]
public readonly record struct BreachedPasswordDetectionMethodEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionMethodEnum Standard = new(Values.Standard);

    public static readonly BreachedPasswordDetectionMethodEnum Enhanced = new(Values.Enhanced);

    public BreachedPasswordDetectionMethodEnum(string value)
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
    public static BreachedPasswordDetectionMethodEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionMethodEnum(value);
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

    public static bool operator ==(BreachedPasswordDetectionMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BreachedPasswordDetectionMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BreachedPasswordDetectionMethodEnum value) =>
        value.Value;

    public static explicit operator BreachedPasswordDetectionMethodEnum(string value) => new(value);

    internal class BreachedPasswordDetectionMethodEnumSerializer
        : JsonConverter<BreachedPasswordDetectionMethodEnum>
    {
        public override BreachedPasswordDetectionMethodEnum Read(
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
            return new BreachedPasswordDetectionMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BreachedPasswordDetectionMethodEnum value,
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
        public const string Standard = "standard";

        public const string Enhanced = "enhanced";
    }
}
