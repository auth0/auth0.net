using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Tenants;

[JsonConverter(typeof(StringEnumSerializer<UpdateTenantSettingsRequestContentEnabledLocalesItem>))]
[Serializable]
public readonly record struct UpdateTenantSettingsRequestContentEnabledLocalesItem : IStringEnum
{
    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Am = new(Values.Am);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ar = new(Values.Ar);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem ArEg = new(
        Values.ArEg
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem ArSa = new(
        Values.ArSa
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Az = new(Values.Az);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Bg = new(Values.Bg);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Bn = new(Values.Bn);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Bs = new(Values.Bs);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem CaEs = new(
        Values.CaEs
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Cnr = new(
        Values.Cnr
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Cs = new(Values.Cs);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Cy = new(Values.Cy);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Da = new(Values.Da);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem De = new(Values.De);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem El = new(Values.El);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem En = new(Values.En);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem EnCa = new(
        Values.EnCa
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Es = new(Values.Es);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Es419 = new(
        Values.Es419
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem EsAr = new(
        Values.EsAr
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem EsMx = new(
        Values.EsMx
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Et = new(Values.Et);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem EuEs = new(
        Values.EuEs
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Fa = new(Values.Fa);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Fi = new(Values.Fi);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Fr = new(Values.Fr);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem FrCa = new(
        Values.FrCa
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem FrFr = new(
        Values.FrFr
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem GlEs = new(
        Values.GlEs
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Gu = new(Values.Gu);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem He = new(Values.He);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Hi = new(Values.Hi);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Hr = new(Values.Hr);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Hu = new(Values.Hu);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Hy = new(Values.Hy);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Id = new(Values.Id);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Is = new(Values.Is);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem It = new(Values.It);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ja = new(Values.Ja);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ka = new(Values.Ka);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Kk = new(Values.Kk);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Kn = new(Values.Kn);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ko = new(Values.Ko);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Lt = new(Values.Lt);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Lv = new(Values.Lv);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Mk = new(Values.Mk);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ml = new(Values.Ml);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Mn = new(Values.Mn);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Mr = new(Values.Mr);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ms = new(Values.Ms);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem My = new(Values.My);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Nb = new(Values.Nb);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Nl = new(Values.Nl);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Nn = new(Values.Nn);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem No = new(Values.No);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Pa = new(Values.Pa);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Pl = new(Values.Pl);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Pt = new(Values.Pt);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem PtBr = new(
        Values.PtBr
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem PtPt = new(
        Values.PtPt
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ro = new(Values.Ro);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ru = new(Values.Ru);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sk = new(Values.Sk);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sl = new(Values.Sl);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem So = new(Values.So);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sq = new(Values.Sq);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sr = new(Values.Sr);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sv = new(Values.Sv);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Sw = new(Values.Sw);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ta = new(Values.Ta);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Te = new(Values.Te);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Th = new(Values.Th);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Tl = new(Values.Tl);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Tr = new(Values.Tr);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Uk = new(Values.Uk);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Ur = new(Values.Ur);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Vi = new(Values.Vi);

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem Zgh = new(
        Values.Zgh
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem ZhCn = new(
        Values.ZhCn
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem ZhHk = new(
        Values.ZhHk
    );

    public static readonly UpdateTenantSettingsRequestContentEnabledLocalesItem ZhTw = new(
        Values.ZhTw
    );

    public UpdateTenantSettingsRequestContentEnabledLocalesItem(string value)
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
    public static UpdateTenantSettingsRequestContentEnabledLocalesItem FromCustom(string value)
    {
        return new UpdateTenantSettingsRequestContentEnabledLocalesItem(value);
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
        UpdateTenantSettingsRequestContentEnabledLocalesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateTenantSettingsRequestContentEnabledLocalesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateTenantSettingsRequestContentEnabledLocalesItem value
    ) => value.Value;

    public static explicit operator UpdateTenantSettingsRequestContentEnabledLocalesItem(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Am = "am";

        public const string Ar = "ar";

        public const string ArEg = "ar-EG";

        public const string ArSa = "ar-SA";

        public const string Az = "az";

        public const string Bg = "bg";

        public const string Bn = "bn";

        public const string Bs = "bs";

        public const string CaEs = "ca-ES";

        public const string Cnr = "cnr";

        public const string Cs = "cs";

        public const string Cy = "cy";

        public const string Da = "da";

        public const string De = "de";

        public const string El = "el";

        public const string En = "en";

        public const string EnCa = "en-CA";

        public const string Es = "es";

        public const string Es419 = "es-419";

        public const string EsAr = "es-AR";

        public const string EsMx = "es-MX";

        public const string Et = "et";

        public const string EuEs = "eu-ES";

        public const string Fa = "fa";

        public const string Fi = "fi";

        public const string Fr = "fr";

        public const string FrCa = "fr-CA";

        public const string FrFr = "fr-FR";

        public const string GlEs = "gl-ES";

        public const string Gu = "gu";

        public const string He = "he";

        public const string Hi = "hi";

        public const string Hr = "hr";

        public const string Hu = "hu";

        public const string Hy = "hy";

        public const string Id = "id";

        public const string Is = "is";

        public const string It = "it";

        public const string Ja = "ja";

        public const string Ka = "ka";

        public const string Kk = "kk";

        public const string Kn = "kn";

        public const string Ko = "ko";

        public const string Lt = "lt";

        public const string Lv = "lv";

        public const string Mk = "mk";

        public const string Ml = "ml";

        public const string Mn = "mn";

        public const string Mr = "mr";

        public const string Ms = "ms";

        public const string My = "my";

        public const string Nb = "nb";

        public const string Nl = "nl";

        public const string Nn = "nn";

        public const string No = "no";

        public const string Pa = "pa";

        public const string Pl = "pl";

        public const string Pt = "pt";

        public const string PtBr = "pt-BR";

        public const string PtPt = "pt-PT";

        public const string Ro = "ro";

        public const string Ru = "ru";

        public const string Sk = "sk";

        public const string Sl = "sl";

        public const string So = "so";

        public const string Sq = "sq";

        public const string Sr = "sr";

        public const string Sv = "sv";

        public const string Sw = "sw";

        public const string Ta = "ta";

        public const string Te = "te";

        public const string Th = "th";

        public const string Tl = "tl";

        public const string Tr = "tr";

        public const string Uk = "uk";

        public const string Ur = "ur";

        public const string Vi = "vi";

        public const string Zgh = "zgh";

        public const string ZhCn = "zh-CN";

        public const string ZhHk = "zh-HK";

        public const string ZhTw = "zh-TW";
    }
}
