using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionHubspotEnrollContactAction>))]
[Serializable]
public readonly record struct FlowActionHubspotEnrollContactAction : IStringEnum
{
    public static readonly FlowActionHubspotEnrollContactAction EnrollContact = new(
        Values.EnrollContact
    );

    public FlowActionHubspotEnrollContactAction(string value)
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
    public static FlowActionHubspotEnrollContactAction FromCustom(string value)
    {
        return new FlowActionHubspotEnrollContactAction(value);
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

    public static bool operator ==(FlowActionHubspotEnrollContactAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHubspotEnrollContactAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHubspotEnrollContactAction value) =>
        value.Value;

    public static explicit operator FlowActionHubspotEnrollContactAction(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string EnrollContact = "ENROLL_CONTACT";
    }
}
