using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientComplianceLevelEnum>))]
[Serializable]
public readonly record struct ClientComplianceLevelEnum : IStringEnum
{
    public static readonly ClientComplianceLevelEnum None = new(Values.None);

    public static readonly ClientComplianceLevelEnum Fapi1AdvPkjPar = new(Values.Fapi1AdvPkjPar);

    public static readonly ClientComplianceLevelEnum Fapi1AdvMtlsPar = new(Values.Fapi1AdvMtlsPar);

    public static readonly ClientComplianceLevelEnum Fapi2SpPkjMtls = new(Values.Fapi2SpPkjMtls);

    public static readonly ClientComplianceLevelEnum Fapi2SpMtlsMtls = new(Values.Fapi2SpMtlsMtls);

    public ClientComplianceLevelEnum(string value)
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
    public static ClientComplianceLevelEnum FromCustom(string value)
    {
        return new ClientComplianceLevelEnum(value);
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

    public static bool operator ==(ClientComplianceLevelEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientComplianceLevelEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientComplianceLevelEnum value) => value.Value;

    public static explicit operator ClientComplianceLevelEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";

        public const string Fapi1AdvPkjPar = "fapi1_adv_pkj_par";

        public const string Fapi1AdvMtlsPar = "fapi1_adv_mtls_par";

        public const string Fapi2SpPkjMtls = "fapi2_sp_pkj_mtls";

        public const string Fapi2SpMtlsMtls = "fapi2_sp_mtls_mtls";
    }
}
