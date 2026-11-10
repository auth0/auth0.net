using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerAgentSubjectClaimsSchemaEnum.ResourceServerAgentSubjectClaimsSchemaEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerAgentSubjectClaimsSchemaEnum : IStringEnum
{
    public static readonly ResourceServerAgentSubjectClaimsSchemaEnum Off = new(Values.Off);

    public static readonly ResourceServerAgentSubjectClaimsSchemaEnum Auth0V1 = new(Values.Auth0V1);

    public ResourceServerAgentSubjectClaimsSchemaEnum(string value)
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
    public static ResourceServerAgentSubjectClaimsSchemaEnum FromCustom(string value)
    {
        return new ResourceServerAgentSubjectClaimsSchemaEnum(value);
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
        ResourceServerAgentSubjectClaimsSchemaEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerAgentSubjectClaimsSchemaEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerAgentSubjectClaimsSchemaEnum value) =>
        value.Value;

    public static explicit operator ResourceServerAgentSubjectClaimsSchemaEnum(string value) =>
        new(value);

    internal class ResourceServerAgentSubjectClaimsSchemaEnumSerializer
        : JsonConverter<ResourceServerAgentSubjectClaimsSchemaEnum>
    {
        public override ResourceServerAgentSubjectClaimsSchemaEnum Read(
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
            return new ResourceServerAgentSubjectClaimsSchemaEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerAgentSubjectClaimsSchemaEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerAgentSubjectClaimsSchemaEnum ReadAsPropertyName(
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
            return new ResourceServerAgentSubjectClaimsSchemaEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerAgentSubjectClaimsSchemaEnum value,
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
        public const string Off = "off";

        public const string Auth0V1 = "auth0-v1";
    }
}
