using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionIdentityApiEnumAzureAd>))]
[Serializable]
public readonly record struct ConnectionIdentityApiEnumAzureAd : IStringEnum
{
    public static readonly ConnectionIdentityApiEnumAzureAd MicrosoftIdentityPlatformV20 = new(
        Values.MicrosoftIdentityPlatformV20
    );

    public static readonly ConnectionIdentityApiEnumAzureAd AzureActiveDirectoryV10 = new(
        Values.AzureActiveDirectoryV10
    );

    public ConnectionIdentityApiEnumAzureAd(string value)
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
    public static ConnectionIdentityApiEnumAzureAd FromCustom(string value)
    {
        return new ConnectionIdentityApiEnumAzureAd(value);
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

    public static bool operator ==(ConnectionIdentityApiEnumAzureAd value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionIdentityApiEnumAzureAd value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionIdentityApiEnumAzureAd value) => value.Value;

    public static explicit operator ConnectionIdentityApiEnumAzureAd(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string MicrosoftIdentityPlatformV20 = "microsoft-identity-platform-v2.0";

        public const string AzureActiveDirectoryV10 = "azure-active-directory-v1.0";
    }
}
