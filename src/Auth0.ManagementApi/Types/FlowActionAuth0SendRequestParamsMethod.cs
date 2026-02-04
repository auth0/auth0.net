using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAuth0SendRequestParamsMethod>))]
[Serializable]
public readonly record struct FlowActionAuth0SendRequestParamsMethod : IStringEnum
{
    public static readonly FlowActionAuth0SendRequestParamsMethod Get = new(Values.Get);

    public static readonly FlowActionAuth0SendRequestParamsMethod Post = new(Values.Post);

    public static readonly FlowActionAuth0SendRequestParamsMethod Put = new(Values.Put);

    public static readonly FlowActionAuth0SendRequestParamsMethod Patch = new(Values.Patch);

    public static readonly FlowActionAuth0SendRequestParamsMethod Delete = new(Values.Delete);

    public FlowActionAuth0SendRequestParamsMethod(string value)
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
    public static FlowActionAuth0SendRequestParamsMethod FromCustom(string value)
    {
        return new FlowActionAuth0SendRequestParamsMethod(value);
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

    public static bool operator ==(FlowActionAuth0SendRequestParamsMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendRequestParamsMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendRequestParamsMethod value) =>
        value.Value;

    public static explicit operator FlowActionAuth0SendRequestParamsMethod(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Get = "GET";

        public const string Post = "POST";

        public const string Put = "PUT";

        public const string Patch = "PATCH";

        public const string Delete = "DELETE";
    }
}
