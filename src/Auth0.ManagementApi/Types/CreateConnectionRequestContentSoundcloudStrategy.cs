using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentSoundcloudStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentSoundcloudStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentSoundcloudStrategy Soundcloud = new(
        Values.Soundcloud
    );

    public CreateConnectionRequestContentSoundcloudStrategy(string value)
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
    public static CreateConnectionRequestContentSoundcloudStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentSoundcloudStrategy(value);
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
        CreateConnectionRequestContentSoundcloudStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentSoundcloudStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentSoundcloudStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentSoundcloudStrategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Soundcloud = "soundcloud";
    }
}
