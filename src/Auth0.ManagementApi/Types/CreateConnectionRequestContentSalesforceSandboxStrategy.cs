using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(StringEnumSerializer<CreateConnectionRequestContentSalesforceSandboxStrategy>)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentSalesforceSandboxStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentSalesforceSandboxStrategy SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public CreateConnectionRequestContentSalesforceSandboxStrategy(string value)
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
    public static CreateConnectionRequestContentSalesforceSandboxStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentSalesforceSandboxStrategy(value);
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
        CreateConnectionRequestContentSalesforceSandboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentSalesforceSandboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentSalesforceSandboxStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentSalesforceSandboxStrategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SalesforceSandbox = "salesforce-sandbox";
    }
}
