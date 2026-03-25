using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SignupStatusEnum.SignupStatusEnumSerializer))]
[Serializable]
public readonly record struct SignupStatusEnum : IStringEnum
{
    public static readonly SignupStatusEnum Required = new(Values.Required);

    public static readonly SignupStatusEnum Optional = new(Values.Optional);

    public static readonly SignupStatusEnum Inactive = new(Values.Inactive);

    public SignupStatusEnum(string value)
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
    public static SignupStatusEnum FromCustom(string value)
    {
        return new SignupStatusEnum(value);
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

    public static bool operator ==(SignupStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SignupStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SignupStatusEnum value) => value.Value;

    public static explicit operator SignupStatusEnum(string value) => new(value);

    internal class SignupStatusEnumSerializer : JsonConverter<SignupStatusEnum>
    {
        public override SignupStatusEnum Read(
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
            return new SignupStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SignupStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SignupStatusEnum ReadAsPropertyName(
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
            return new SignupStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SignupStatusEnum value,
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
        public const string Required = "required";

        public const string Optional = "optional";

        public const string Inactive = "inactive";
    }
}
