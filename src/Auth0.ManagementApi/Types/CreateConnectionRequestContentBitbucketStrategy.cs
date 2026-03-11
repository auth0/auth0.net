using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentBitbucketStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentBitbucketStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentBitbucketStrategy Bitbucket = new(
        Values.Bitbucket
    );

    public CreateConnectionRequestContentBitbucketStrategy(string value)
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
    public static CreateConnectionRequestContentBitbucketStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentBitbucketStrategy(value);
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
        CreateConnectionRequestContentBitbucketStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentBitbucketStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentBitbucketStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentBitbucketStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Bitbucket = "bitbucket";
    }
}
