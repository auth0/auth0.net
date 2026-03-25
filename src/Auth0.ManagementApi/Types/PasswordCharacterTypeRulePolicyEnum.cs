using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PasswordCharacterTypeRulePolicyEnum.PasswordCharacterTypeRulePolicyEnumSerializer)
)]
[Serializable]
public readonly record struct PasswordCharacterTypeRulePolicyEnum : IStringEnum
{
    public static readonly PasswordCharacterTypeRulePolicyEnum All = new(Values.All);

    public static readonly PasswordCharacterTypeRulePolicyEnum ThreeOfFour = new(
        Values.ThreeOfFour
    );

    public PasswordCharacterTypeRulePolicyEnum(string value)
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
    public static PasswordCharacterTypeRulePolicyEnum FromCustom(string value)
    {
        return new PasswordCharacterTypeRulePolicyEnum(value);
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

    public static bool operator ==(PasswordCharacterTypeRulePolicyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PasswordCharacterTypeRulePolicyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PasswordCharacterTypeRulePolicyEnum value) =>
        value.Value;

    public static explicit operator PasswordCharacterTypeRulePolicyEnum(string value) => new(value);

    internal class PasswordCharacterTypeRulePolicyEnumSerializer
        : JsonConverter<PasswordCharacterTypeRulePolicyEnum>
    {
        public override PasswordCharacterTypeRulePolicyEnum Read(
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
            return new PasswordCharacterTypeRulePolicyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PasswordCharacterTypeRulePolicyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PasswordCharacterTypeRulePolicyEnum ReadAsPropertyName(
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
            return new PasswordCharacterTypeRulePolicyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PasswordCharacterTypeRulePolicyEnum value,
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
        public const string All = "all";

        public const string ThreeOfFour = "three_of_four";
    }
}
