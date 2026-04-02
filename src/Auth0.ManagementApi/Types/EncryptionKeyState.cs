using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EncryptionKeyState.EncryptionKeyStateSerializer))]
[Serializable]
public readonly record struct EncryptionKeyState : IStringEnum
{
    public static readonly EncryptionKeyState PreActivation = new(Values.PreActivation);

    public static readonly EncryptionKeyState Active = new(Values.Active);

    public static readonly EncryptionKeyState Deactivated = new(Values.Deactivated);

    public static readonly EncryptionKeyState Destroyed = new(Values.Destroyed);

    public EncryptionKeyState(string value)
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
    public static EncryptionKeyState FromCustom(string value)
    {
        return new EncryptionKeyState(value);
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

    public static bool operator ==(EncryptionKeyState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EncryptionKeyState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EncryptionKeyState value) => value.Value;

    public static explicit operator EncryptionKeyState(string value) => new(value);

    internal class EncryptionKeyStateSerializer : JsonConverter<EncryptionKeyState>
    {
        public override EncryptionKeyState Read(
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
            return new EncryptionKeyState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EncryptionKeyState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EncryptionKeyState ReadAsPropertyName(
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
            return new EncryptionKeyState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EncryptionKeyState value,
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
        public const string PreActivation = "pre-activation";

        public const string Active = "active";

        public const string Deactivated = "deactivated";

        public const string Destroyed = "destroyed";
    }
}
