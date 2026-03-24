using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentGoogleOAuth2Strategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentGoogleOAuth2Strategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentGoogleOAuth2Strategy GoogleOauth2 = new(
        Values.GoogleOauth2
    );

    public CreateConnectionRequestContentGoogleOAuth2Strategy(string value)
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
    public static CreateConnectionRequestContentGoogleOAuth2Strategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentGoogleOAuth2Strategy(value);
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
        CreateConnectionRequestContentGoogleOAuth2Strategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentGoogleOAuth2Strategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentGoogleOAuth2Strategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentGoogleOAuth2Strategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GoogleOauth2 = "google-oauth2";
    }
}
