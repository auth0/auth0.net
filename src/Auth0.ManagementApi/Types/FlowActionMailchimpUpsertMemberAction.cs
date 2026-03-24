using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionMailchimpUpsertMemberAction>))]
[Serializable]
public readonly record struct FlowActionMailchimpUpsertMemberAction : IStringEnum
{
    public static readonly FlowActionMailchimpUpsertMemberAction UpsertMember = new(
        Values.UpsertMember
    );

    public FlowActionMailchimpUpsertMemberAction(string value)
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
    public static FlowActionMailchimpUpsertMemberAction FromCustom(string value)
    {
        return new FlowActionMailchimpUpsertMemberAction(value);
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

    public static bool operator ==(FlowActionMailchimpUpsertMemberAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionMailchimpUpsertMemberAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionMailchimpUpsertMemberAction value) =>
        value.Value;

    public static explicit operator FlowActionMailchimpUpsertMemberAction(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UpsertMember = "UPSERT_MEMBER";
    }
}
