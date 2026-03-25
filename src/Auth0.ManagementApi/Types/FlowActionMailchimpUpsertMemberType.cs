using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionMailchimpUpsertMemberType.FlowActionMailchimpUpsertMemberTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionMailchimpUpsertMemberType : IStringEnum
{
    public static readonly FlowActionMailchimpUpsertMemberType Mailchimp = new(Values.Mailchimp);

    public FlowActionMailchimpUpsertMemberType(string value)
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
    public static FlowActionMailchimpUpsertMemberType FromCustom(string value)
    {
        return new FlowActionMailchimpUpsertMemberType(value);
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

    public static bool operator ==(FlowActionMailchimpUpsertMemberType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionMailchimpUpsertMemberType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionMailchimpUpsertMemberType value) =>
        value.Value;

    public static explicit operator FlowActionMailchimpUpsertMemberType(string value) => new(value);

    internal class FlowActionMailchimpUpsertMemberTypeSerializer
        : JsonConverter<FlowActionMailchimpUpsertMemberType>
    {
        public override FlowActionMailchimpUpsertMemberType Read(
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
            return new FlowActionMailchimpUpsertMemberType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionMailchimpUpsertMemberType value,
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
        public const string Mailchimp = "MAILCHIMP";
    }
}
