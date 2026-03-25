using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionPipedriveAddOrganizationAction.FlowActionPipedriveAddOrganizationActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionPipedriveAddOrganizationAction : IStringEnum
{
    public static readonly FlowActionPipedriveAddOrganizationAction AddOrganization = new(
        Values.AddOrganization
    );

    public FlowActionPipedriveAddOrganizationAction(string value)
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
    public static FlowActionPipedriveAddOrganizationAction FromCustom(string value)
    {
        return new FlowActionPipedriveAddOrganizationAction(value);
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
        FlowActionPipedriveAddOrganizationAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionPipedriveAddOrganizationAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionPipedriveAddOrganizationAction value) =>
        value.Value;

    public static explicit operator FlowActionPipedriveAddOrganizationAction(string value) =>
        new(value);

    internal class FlowActionPipedriveAddOrganizationActionSerializer
        : JsonConverter<FlowActionPipedriveAddOrganizationAction>
    {
        public override FlowActionPipedriveAddOrganizationAction Read(
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
            return new FlowActionPipedriveAddOrganizationAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionPipedriveAddOrganizationAction value,
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
        public const string AddOrganization = "ADD_ORGANIZATION";
    }
}
