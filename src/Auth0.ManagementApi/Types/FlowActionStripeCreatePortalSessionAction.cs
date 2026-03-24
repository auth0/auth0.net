using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionStripeCreatePortalSessionAction.FlowActionStripeCreatePortalSessionActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionStripeCreatePortalSessionAction : IStringEnum
{
    public static readonly FlowActionStripeCreatePortalSessionAction CreatePortalSession = new(
        Values.CreatePortalSession
    );

    public FlowActionStripeCreatePortalSessionAction(string value)
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
    public static FlowActionStripeCreatePortalSessionAction FromCustom(string value)
    {
        return new FlowActionStripeCreatePortalSessionAction(value);
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
        FlowActionStripeCreatePortalSessionAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionStripeCreatePortalSessionAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionStripeCreatePortalSessionAction value) =>
        value.Value;

    public static explicit operator FlowActionStripeCreatePortalSessionAction(string value) =>
        new(value);

    internal class FlowActionStripeCreatePortalSessionActionSerializer
        : JsonConverter<FlowActionStripeCreatePortalSessionAction>
    {
        public override FlowActionStripeCreatePortalSessionAction Read(
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
            return new FlowActionStripeCreatePortalSessionAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripeCreatePortalSessionAction value,
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
        public const string CreatePortalSession = "CREATE_PORTAL_SESSION";
    }
}
