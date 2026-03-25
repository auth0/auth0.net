using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeFindCustomersAction.FlowActionStripeFindCustomersActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeFindCustomersAction : IStringEnum
{
    public static readonly FlowActionStripeFindCustomersAction FindCustomers = new(
        Values.FindCustomers
    );

    public FlowActionStripeFindCustomersAction(string value)
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
    public static FlowActionStripeFindCustomersAction FromCustom(string value)
    {
        return new FlowActionStripeFindCustomersAction(value);
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

    public static bool operator ==(FlowActionStripeFindCustomersAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionStripeFindCustomersAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeFindCustomersAction value) =>
        value.Value;

    public static explicit operator FlowActionStripeFindCustomersAction(string value) => new(value);

    internal class FlowActionStripeFindCustomersActionSerializer
        : JsonConverter<FlowActionStripeFindCustomersAction>
    {
        public override FlowActionStripeFindCustomersAction Read(
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
            return new FlowActionStripeFindCustomersAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeFindCustomersAction value,
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
        public const string FindCustomers = "FIND_CUSTOMERS";
    }
}
