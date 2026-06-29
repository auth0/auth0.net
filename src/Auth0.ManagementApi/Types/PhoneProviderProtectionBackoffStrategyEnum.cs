using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PhoneProviderProtectionBackoffStrategyEnum.PhoneProviderProtectionBackoffStrategyEnumSerializer)
)]
[Serializable]
public readonly record struct PhoneProviderProtectionBackoffStrategyEnum : IStringEnum
{
    public static readonly PhoneProviderProtectionBackoffStrategyEnum Exponential = new(
        Values.Exponential
    );

    public static readonly PhoneProviderProtectionBackoffStrategyEnum None = new(Values.None);

    public PhoneProviderProtectionBackoffStrategyEnum(string value)
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
    public static PhoneProviderProtectionBackoffStrategyEnum FromCustom(string value)
    {
        return new PhoneProviderProtectionBackoffStrategyEnum(value);
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
        PhoneProviderProtectionBackoffStrategyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PhoneProviderProtectionBackoffStrategyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PhoneProviderProtectionBackoffStrategyEnum value) =>
        value.Value;

    public static explicit operator PhoneProviderProtectionBackoffStrategyEnum(string value) =>
        new(value);

    internal class PhoneProviderProtectionBackoffStrategyEnumSerializer
        : JsonConverter<PhoneProviderProtectionBackoffStrategyEnum>
    {
        public override PhoneProviderProtectionBackoffStrategyEnum Read(
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
            return new PhoneProviderProtectionBackoffStrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneProviderProtectionBackoffStrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneProviderProtectionBackoffStrategyEnum ReadAsPropertyName(
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
            return new PhoneProviderProtectionBackoffStrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneProviderProtectionBackoffStrategyEnum value,
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
        public const string Exponential = "exponential";

        public const string None = "none";
    }
}
