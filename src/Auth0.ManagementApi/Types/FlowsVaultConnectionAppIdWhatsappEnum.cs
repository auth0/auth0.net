using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionAppIdWhatsappEnum.FlowsVaultConnectionAppIdWhatsappEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdWhatsappEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdWhatsappEnum Whatsapp = new(Values.Whatsapp);

    public FlowsVaultConnectionAppIdWhatsappEnum(string value)
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
    public static FlowsVaultConnectionAppIdWhatsappEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdWhatsappEnum(value);
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

    public static bool operator ==(FlowsVaultConnectionAppIdWhatsappEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionAppIdWhatsappEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdWhatsappEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionAppIdWhatsappEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionAppIdWhatsappEnumSerializer
        : JsonConverter<FlowsVaultConnectionAppIdWhatsappEnum>
    {
        public override FlowsVaultConnectionAppIdWhatsappEnum Read(
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
            return new FlowsVaultConnectionAppIdWhatsappEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdWhatsappEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowsVaultConnectionAppIdWhatsappEnum ReadAsPropertyName(
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
            return new FlowsVaultConnectionAppIdWhatsappEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdWhatsappEnum value,
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
        public const string Whatsapp = "WHATSAPP";
    }
}
