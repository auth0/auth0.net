using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionProtocolBindingEnumSaml>))]
[Serializable]
public readonly record struct ConnectionProtocolBindingEnumSaml : IStringEnum
{
    public static readonly ConnectionProtocolBindingEnumSaml UrnOasisNamesTcSaml20BindingsHttpPost =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpPost);

    public static readonly ConnectionProtocolBindingEnumSaml UrnOasisNamesTcSaml20BindingsHttpRedirect =
        new(Values.UrnOasisNamesTcSaml20BindingsHttpRedirect);

    public ConnectionProtocolBindingEnumSaml(string value)
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
    public static ConnectionProtocolBindingEnumSaml FromCustom(string value)
    {
        return new ConnectionProtocolBindingEnumSaml(value);
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

    public static bool operator ==(ConnectionProtocolBindingEnumSaml value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionProtocolBindingEnumSaml value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionProtocolBindingEnumSaml value) => value.Value;

    public static explicit operator ConnectionProtocolBindingEnumSaml(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string UrnOasisNamesTcSaml20BindingsHttpPost =
            "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";

        public const string UrnOasisNamesTcSaml20BindingsHttpRedirect =
            "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect";
    }
}
