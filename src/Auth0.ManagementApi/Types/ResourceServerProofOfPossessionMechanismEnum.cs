using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerProofOfPossessionMechanismEnum.ResourceServerProofOfPossessionMechanismEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerProofOfPossessionMechanismEnum : IStringEnum
{
    public static readonly ResourceServerProofOfPossessionMechanismEnum Mtls = new(Values.Mtls);

    public static readonly ResourceServerProofOfPossessionMechanismEnum Dpop = new(Values.Dpop);

    public ResourceServerProofOfPossessionMechanismEnum(string value)
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
    public static ResourceServerProofOfPossessionMechanismEnum FromCustom(string value)
    {
        return new ResourceServerProofOfPossessionMechanismEnum(value);
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
        ResourceServerProofOfPossessionMechanismEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerProofOfPossessionMechanismEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerProofOfPossessionMechanismEnum value) =>
        value.Value;

    public static explicit operator ResourceServerProofOfPossessionMechanismEnum(string value) =>
        new(value);

    internal class ResourceServerProofOfPossessionMechanismEnumSerializer
        : JsonConverter<ResourceServerProofOfPossessionMechanismEnum>
    {
        public override ResourceServerProofOfPossessionMechanismEnum Read(
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
            return new ResourceServerProofOfPossessionMechanismEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerProofOfPossessionMechanismEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerProofOfPossessionMechanismEnum ReadAsPropertyName(
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
            return new ResourceServerProofOfPossessionMechanismEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerProofOfPossessionMechanismEnum value,
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
        public const string Mtls = "mtls";

        public const string Dpop = "dpop";
    }
}
