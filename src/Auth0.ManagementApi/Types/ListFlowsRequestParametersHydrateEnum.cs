using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ListFlowsRequestParametersHydrateEnum>))]
[Serializable]
public readonly record struct ListFlowsRequestParametersHydrateEnum : IStringEnum
{
    public static readonly ListFlowsRequestParametersHydrateEnum FormCount = new(Values.FormCount);

    public ListFlowsRequestParametersHydrateEnum(string value)
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
    public static ListFlowsRequestParametersHydrateEnum FromCustom(string value)
    {
        return new ListFlowsRequestParametersHydrateEnum(value);
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

    public static bool operator ==(ListFlowsRequestParametersHydrateEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListFlowsRequestParametersHydrateEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListFlowsRequestParametersHydrateEnum value) =>
        value.Value;

    public static explicit operator ListFlowsRequestParametersHydrateEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FormCount = "form_count";
    }
}
