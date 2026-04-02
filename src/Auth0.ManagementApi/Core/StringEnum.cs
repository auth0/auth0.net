namespace Auth0.ManagementApi.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
