using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionHttpSendRequestParamsMethod>))]
[Serializable]
public readonly record struct FlowActionHttpSendRequestParamsMethod : IStringEnum
{
    public static readonly FlowActionHttpSendRequestParamsMethod Get = new(Values.Get);

    public static readonly FlowActionHttpSendRequestParamsMethod Post = new(Values.Post);

    public static readonly FlowActionHttpSendRequestParamsMethod Put = new(Values.Put);

    public static readonly FlowActionHttpSendRequestParamsMethod Patch = new(Values.Patch);

    public static readonly FlowActionHttpSendRequestParamsMethod Delete = new(Values.Delete);

    public FlowActionHttpSendRequestParamsMethod(string value)
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
    public static FlowActionHttpSendRequestParamsMethod FromCustom(string value)
    {
        return new FlowActionHttpSendRequestParamsMethod(value);
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

    public static bool operator ==(FlowActionHttpSendRequestParamsMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionHttpSendRequestParamsMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHttpSendRequestParamsMethod value) =>
        value.Value;

    public static explicit operator FlowActionHttpSendRequestParamsMethod(string value) =>
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
