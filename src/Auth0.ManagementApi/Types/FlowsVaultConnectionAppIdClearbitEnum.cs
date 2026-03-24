using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionAppIdClearbitEnum.FlowsVaultConnectionAppIdClearbitEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdClearbitEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdClearbitEnum Clearbit = new(Values.Clearbit);

    public FlowsVaultConnectionAppIdClearbitEnum(string value)
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
    public static FlowsVaultConnectionAppIdClearbitEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdClearbitEnum(value);
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

    public static bool operator ==(FlowsVaultConnectionAppIdClearbitEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionAppIdClearbitEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdClearbitEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionAppIdClearbitEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionAppIdClearbitEnumSerializer
        : JsonConverter<FlowsVaultConnectionAppIdClearbitEnum>
    {
        public override FlowsVaultConnectionAppIdClearbitEnum Read(
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
            return new FlowsVaultConnectionAppIdClearbitEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdClearbitEnum value,
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
        public const string Clearbit = "CLEARBIT";
    }
}
