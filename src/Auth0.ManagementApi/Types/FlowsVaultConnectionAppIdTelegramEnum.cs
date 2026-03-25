using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionAppIdTelegramEnum.FlowsVaultConnectionAppIdTelegramEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdTelegramEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdTelegramEnum Telegram = new(Values.Telegram);

    public FlowsVaultConnectionAppIdTelegramEnum(string value)
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
    public static FlowsVaultConnectionAppIdTelegramEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdTelegramEnum(value);
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

    public static bool operator ==(FlowsVaultConnectionAppIdTelegramEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowsVaultConnectionAppIdTelegramEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdTelegramEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionAppIdTelegramEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionAppIdTelegramEnumSerializer
        : JsonConverter<FlowsVaultConnectionAppIdTelegramEnum>
    {
        public override FlowsVaultConnectionAppIdTelegramEnum Read(
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
            return new FlowsVaultConnectionAppIdTelegramEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdTelegramEnum value,
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
        public const string Telegram = "TELEGRAM";
    }
}
