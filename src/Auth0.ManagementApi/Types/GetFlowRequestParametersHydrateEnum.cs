using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<GetFlowRequestParametersHydrateEnum>))]
[Serializable]
public readonly record struct GetFlowRequestParametersHydrateEnum : IStringEnum
{
    public static readonly GetFlowRequestParametersHydrateEnum FormCount = new(Values.FormCount);

    public static readonly GetFlowRequestParametersHydrateEnum Forms = new(Values.Forms);

    public GetFlowRequestParametersHydrateEnum(string value)
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
    public static GetFlowRequestParametersHydrateEnum FromCustom(string value)
    {
        return new GetFlowRequestParametersHydrateEnum(value);
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

    public static bool operator ==(GetFlowRequestParametersHydrateEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetFlowRequestParametersHydrateEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetFlowRequestParametersHydrateEnum value) =>
        value.Value;

    public static explicit operator GetFlowRequestParametersHydrateEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FormCount = "form_count";

        public const string Forms = "forms";
    }
}
