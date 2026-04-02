using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionPipedriveAddOrganizationType.FlowActionPipedriveAddOrganizationTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionPipedriveAddOrganizationType : IStringEnum
{
    public static readonly FlowActionPipedriveAddOrganizationType Pipedrive = new(Values.Pipedrive);

    public FlowActionPipedriveAddOrganizationType(string value)
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
    public static FlowActionPipedriveAddOrganizationType FromCustom(string value)
    {
        return new FlowActionPipedriveAddOrganizationType(value);
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

    public static bool operator ==(FlowActionPipedriveAddOrganizationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionPipedriveAddOrganizationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionPipedriveAddOrganizationType value) =>
        value.Value;

    public static explicit operator FlowActionPipedriveAddOrganizationType(string value) =>
        new(value);

    internal class FlowActionPipedriveAddOrganizationTypeSerializer
        : JsonConverter<FlowActionPipedriveAddOrganizationType>
    {
        public override FlowActionPipedriveAddOrganizationType Read(
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
            return new FlowActionPipedriveAddOrganizationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionPipedriveAddOrganizationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionPipedriveAddOrganizationType ReadAsPropertyName(
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
            return new FlowActionPipedriveAddOrganizationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionPipedriveAddOrganizationType value,
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
        public const string Pipedrive = "PIPEDRIVE";
    }
}
