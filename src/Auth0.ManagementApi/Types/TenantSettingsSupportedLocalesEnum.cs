using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<TenantSettingsSupportedLocalesEnum>))]
[Serializable]
public readonly record struct TenantSettingsSupportedLocalesEnum : IStringEnum
{
    public static readonly TenantSettingsSupportedLocalesEnum Am = new(Values.Am);

    public static readonly TenantSettingsSupportedLocalesEnum Ar = new(Values.Ar);

    public static readonly TenantSettingsSupportedLocalesEnum ArEg = new(Values.ArEg);

    public static readonly TenantSettingsSupportedLocalesEnum ArSa = new(Values.ArSa);

    public static readonly TenantSettingsSupportedLocalesEnum Az = new(Values.Az);

    public static readonly TenantSettingsSupportedLocalesEnum Bg = new(Values.Bg);

    public static readonly TenantSettingsSupportedLocalesEnum Bn = new(Values.Bn);

    public static readonly TenantSettingsSupportedLocalesEnum Bs = new(Values.Bs);

    public static readonly TenantSettingsSupportedLocalesEnum CaEs = new(Values.CaEs);

    public static readonly TenantSettingsSupportedLocalesEnum Cnr = new(Values.Cnr);

    public static readonly TenantSettingsSupportedLocalesEnum Cs = new(Values.Cs);

    public static readonly TenantSettingsSupportedLocalesEnum Cy = new(Values.Cy);

    public static readonly TenantSettingsSupportedLocalesEnum Da = new(Values.Da);

    public static readonly TenantSettingsSupportedLocalesEnum De = new(Values.De);

    public static readonly TenantSettingsSupportedLocalesEnum El = new(Values.El);

    public static readonly TenantSettingsSupportedLocalesEnum En = new(Values.En);

    public static readonly TenantSettingsSupportedLocalesEnum EnCa = new(Values.EnCa);

    public static readonly TenantSettingsSupportedLocalesEnum Es = new(Values.Es);

    public static readonly TenantSettingsSupportedLocalesEnum Es419 = new(Values.Es419);

    public static readonly TenantSettingsSupportedLocalesEnum EsAr = new(Values.EsAr);

    public static readonly TenantSettingsSupportedLocalesEnum EsMx = new(Values.EsMx);

    public static readonly TenantSettingsSupportedLocalesEnum Et = new(Values.Et);

    public static readonly TenantSettingsSupportedLocalesEnum EuEs = new(Values.EuEs);

    public static readonly TenantSettingsSupportedLocalesEnum Fa = new(Values.Fa);

    public static readonly TenantSettingsSupportedLocalesEnum Fi = new(Values.Fi);

    public static readonly TenantSettingsSupportedLocalesEnum Fr = new(Values.Fr);

    public static readonly TenantSettingsSupportedLocalesEnum FrCa = new(Values.FrCa);

    public static readonly TenantSettingsSupportedLocalesEnum FrFr = new(Values.FrFr);

    public static readonly TenantSettingsSupportedLocalesEnum GlEs = new(Values.GlEs);

    public static readonly TenantSettingsSupportedLocalesEnum Gu = new(Values.Gu);

    public static readonly TenantSettingsSupportedLocalesEnum He = new(Values.He);

    public static readonly TenantSettingsSupportedLocalesEnum Hi = new(Values.Hi);

    public static readonly TenantSettingsSupportedLocalesEnum Hr = new(Values.Hr);

    public static readonly TenantSettingsSupportedLocalesEnum Hu = new(Values.Hu);

    public static readonly TenantSettingsSupportedLocalesEnum Hy = new(Values.Hy);

    public static readonly TenantSettingsSupportedLocalesEnum Id = new(Values.Id);

    public static readonly TenantSettingsSupportedLocalesEnum Is = new(Values.Is);

    public static readonly TenantSettingsSupportedLocalesEnum It = new(Values.It);

    public static readonly TenantSettingsSupportedLocalesEnum Ja = new(Values.Ja);

    public static readonly TenantSettingsSupportedLocalesEnum Ka = new(Values.Ka);

    public static readonly TenantSettingsSupportedLocalesEnum Kk = new(Values.Kk);

    public static readonly TenantSettingsSupportedLocalesEnum Kn = new(Values.Kn);

    public static readonly TenantSettingsSupportedLocalesEnum Ko = new(Values.Ko);

    public static readonly TenantSettingsSupportedLocalesEnum Lt = new(Values.Lt);

    public static readonly TenantSettingsSupportedLocalesEnum Lv = new(Values.Lv);

    public static readonly TenantSettingsSupportedLocalesEnum Mk = new(Values.Mk);

    public static readonly TenantSettingsSupportedLocalesEnum Ml = new(Values.Ml);

    public static readonly TenantSettingsSupportedLocalesEnum Mn = new(Values.Mn);

    public static readonly TenantSettingsSupportedLocalesEnum Mr = new(Values.Mr);

    public static readonly TenantSettingsSupportedLocalesEnum Ms = new(Values.Ms);

    public static readonly TenantSettingsSupportedLocalesEnum My = new(Values.My);

    public static readonly TenantSettingsSupportedLocalesEnum Nb = new(Values.Nb);

    public static readonly TenantSettingsSupportedLocalesEnum Nl = new(Values.Nl);

    public static readonly TenantSettingsSupportedLocalesEnum Nn = new(Values.Nn);

    public static readonly TenantSettingsSupportedLocalesEnum No = new(Values.No);

    public static readonly TenantSettingsSupportedLocalesEnum Pa = new(Values.Pa);

    public static readonly TenantSettingsSupportedLocalesEnum Pl = new(Values.Pl);

    public static readonly TenantSettingsSupportedLocalesEnum Pt = new(Values.Pt);

    public static readonly TenantSettingsSupportedLocalesEnum PtBr = new(Values.PtBr);

    public static readonly TenantSettingsSupportedLocalesEnum PtPt = new(Values.PtPt);

    public static readonly TenantSettingsSupportedLocalesEnum Ro = new(Values.Ro);

    public static readonly TenantSettingsSupportedLocalesEnum Ru = new(Values.Ru);

    public static readonly TenantSettingsSupportedLocalesEnum Sk = new(Values.Sk);

    public static readonly TenantSettingsSupportedLocalesEnum Sl = new(Values.Sl);

    public static readonly TenantSettingsSupportedLocalesEnum So = new(Values.So);

    public static readonly TenantSettingsSupportedLocalesEnum Sq = new(Values.Sq);

    public static readonly TenantSettingsSupportedLocalesEnum Sr = new(Values.Sr);

    public static readonly TenantSettingsSupportedLocalesEnum Sv = new(Values.Sv);

    public static readonly TenantSettingsSupportedLocalesEnum Sw = new(Values.Sw);

    public static readonly TenantSettingsSupportedLocalesEnum Ta = new(Values.Ta);

    public static readonly TenantSettingsSupportedLocalesEnum Te = new(Values.Te);

    public static readonly TenantSettingsSupportedLocalesEnum Th = new(Values.Th);

    public static readonly TenantSettingsSupportedLocalesEnum Tl = new(Values.Tl);

    public static readonly TenantSettingsSupportedLocalesEnum Tr = new(Values.Tr);

    public static readonly TenantSettingsSupportedLocalesEnum Uk = new(Values.Uk);

    public static readonly TenantSettingsSupportedLocalesEnum Ur = new(Values.Ur);

    public static readonly TenantSettingsSupportedLocalesEnum Vi = new(Values.Vi);

    public static readonly TenantSettingsSupportedLocalesEnum Zgh = new(Values.Zgh);

    public static readonly TenantSettingsSupportedLocalesEnum ZhCn = new(Values.ZhCn);

    public static readonly TenantSettingsSupportedLocalesEnum ZhHk = new(Values.ZhHk);

    public static readonly TenantSettingsSupportedLocalesEnum ZhMo = new(Values.ZhMo);

    public static readonly TenantSettingsSupportedLocalesEnum ZhTw = new(Values.ZhTw);

    public TenantSettingsSupportedLocalesEnum(string value)
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
    public static TenantSettingsSupportedLocalesEnum FromCustom(string value)
    {
        return new TenantSettingsSupportedLocalesEnum(value);
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

    public static bool operator ==(TenantSettingsSupportedLocalesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenantSettingsSupportedLocalesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenantSettingsSupportedLocalesEnum value) => value.Value;

    public static explicit operator TenantSettingsSupportedLocalesEnum(string value) => new(value);

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

        public const string ZhMo = "zh-MO";

        public const string ZhTw = "zh-TW";
    }
}
