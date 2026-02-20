using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ResourceServerProofOfPossessionRequiredForEnum>))]
[Serializable]
public readonly record struct ResourceServerProofOfPossessionRequiredForEnum : IStringEnum
{
    public static readonly ResourceServerProofOfPossessionRequiredForEnum PublicClients = new(
        Values.PublicClients
    );

    public static readonly ResourceServerProofOfPossessionRequiredForEnum ConfidentialClients = new(
        Values.ConfidentialClients
    );

    public static readonly ResourceServerProofOfPossessionRequiredForEnum AllClients = new(
        Values.AllClients
    );

    public ResourceServerProofOfPossessionRequiredForEnum(string value)
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
    public static ResourceServerProofOfPossessionRequiredForEnum FromCustom(string value)
    {
        return new ResourceServerProofOfPossessionRequiredForEnum(value);
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
        ResourceServerProofOfPossessionRequiredForEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerProofOfPossessionRequiredForEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceServerProofOfPossessionRequiredForEnum value) =>
        value.Value;

    public static explicit operator ResourceServerProofOfPossessionRequiredForEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PublicClients = "public_clients";

        public const string ConfidentialClients = "confidential_clients";

        public const string AllClients = "all_clients";
    }
}
