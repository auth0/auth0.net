using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(UpdateBrandingLoginDisplayEnum.UpdateBrandingLoginDisplayEnumSerializer))]
[Serializable]
public readonly record struct UpdateBrandingLoginDisplayEnum : IStringEnum
{
    public static readonly UpdateBrandingLoginDisplayEnum Unified = new(Values.Unified);

    public static readonly UpdateBrandingLoginDisplayEnum Separate = new(Values.Separate);

    public UpdateBrandingLoginDisplayEnum(string value)
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
    public static UpdateBrandingLoginDisplayEnum FromCustom(string value)
    {
        return new UpdateBrandingLoginDisplayEnum(value);
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

    public static bool operator ==(UpdateBrandingLoginDisplayEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateBrandingLoginDisplayEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBrandingLoginDisplayEnum value) => value.Value;

    public static explicit operator UpdateBrandingLoginDisplayEnum(string value) => new(value);

    internal class UpdateBrandingLoginDisplayEnumSerializer
        : JsonConverter<UpdateBrandingLoginDisplayEnum>
    {
        public override UpdateBrandingLoginDisplayEnum Read(
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
            return new UpdateBrandingLoginDisplayEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBrandingLoginDisplayEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBrandingLoginDisplayEnum ReadAsPropertyName(
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
            return new UpdateBrandingLoginDisplayEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBrandingLoginDisplayEnum value,
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
        public const string Unified = "unified";

        public const string Separate = "separate";
    }
}
