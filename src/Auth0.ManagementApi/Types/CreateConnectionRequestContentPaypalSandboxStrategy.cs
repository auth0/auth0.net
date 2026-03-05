using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentPaypalSandboxStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentPaypalSandboxStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentPaypalSandboxStrategy PaypalSandbox = new(
        Values.PaypalSandbox
    );

    public CreateConnectionRequestContentPaypalSandboxStrategy(string value)
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
    public static CreateConnectionRequestContentPaypalSandboxStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentPaypalSandboxStrategy(value);
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
        CreateConnectionRequestContentPaypalSandboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentPaypalSandboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentPaypalSandboxStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentPaypalSandboxStrategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PaypalSandbox = "paypal-sandbox";
    }
}
