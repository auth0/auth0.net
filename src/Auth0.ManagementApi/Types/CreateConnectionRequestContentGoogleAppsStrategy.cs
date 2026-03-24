using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentGoogleAppsStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentGoogleAppsStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentGoogleAppsStrategy GoogleApps = new(
        Values.GoogleApps
    );

    public CreateConnectionRequestContentGoogleAppsStrategy(string value)
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
    public static CreateConnectionRequestContentGoogleAppsStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentGoogleAppsStrategy(value);
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
        CreateConnectionRequestContentGoogleAppsStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentGoogleAppsStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentGoogleAppsStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentGoogleAppsStrategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GoogleApps = "google-apps";
    }
}
