using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SupportedLocales>))]
[Serializable]
public readonly record struct SupportedLocales : IStringEnum
{
    public static readonly SupportedLocales Am = new(Values.Am);

    public static readonly SupportedLocales Ar = new(Values.Ar);

    public static readonly SupportedLocales ArEg = new(Values.ArEg);

    public static readonly SupportedLocales ArSa = new(Values.ArSa);

    public static readonly SupportedLocales Az = new(Values.Az);

    public static readonly SupportedLocales Bg = new(Values.Bg);

    public static readonly SupportedLocales Bn = new(Values.Bn);

    public static readonly SupportedLocales Bs = new(Values.Bs);

    public static readonly SupportedLocales CaEs = new(Values.CaEs);

    public static readonly SupportedLocales Cnr = new(Values.Cnr);

    public static readonly SupportedLocales Cs = new(Values.Cs);

    public static readonly SupportedLocales Cy = new(Values.Cy);

    public static readonly SupportedLocales Da = new(Values.Da);

    public static readonly SupportedLocales De = new(Values.De);

    public static readonly SupportedLocales El = new(Values.El);

    public static readonly SupportedLocales En = new(Values.En);

    public static readonly SupportedLocales EnCa = new(Values.EnCa);

    public static readonly SupportedLocales Es = new(Values.Es);

    public static readonly SupportedLocales Es419 = new(Values.Es419);

    public static readonly SupportedLocales EsAr = new(Values.EsAr);

    public static readonly SupportedLocales EsMx = new(Values.EsMx);

    public static readonly SupportedLocales Et = new(Values.Et);

    public static readonly SupportedLocales EuEs = new(Values.EuEs);

    public static readonly SupportedLocales Fa = new(Values.Fa);

    public static readonly SupportedLocales Fi = new(Values.Fi);

    public static readonly SupportedLocales Fr = new(Values.Fr);

    public static readonly SupportedLocales FrCa = new(Values.FrCa);

    public static readonly SupportedLocales FrFr = new(Values.FrFr);

    public static readonly SupportedLocales GlEs = new(Values.GlEs);

    public static readonly SupportedLocales Gu = new(Values.Gu);

    public static readonly SupportedLocales He = new(Values.He);

    public static readonly SupportedLocales Hi = new(Values.Hi);

    public static readonly SupportedLocales Hr = new(Values.Hr);

    public static readonly SupportedLocales Hu = new(Values.Hu);

    public static readonly SupportedLocales Hy = new(Values.Hy);

    public static readonly SupportedLocales Id = new(Values.Id);

    public static readonly SupportedLocales Is = new(Values.Is);

    public static readonly SupportedLocales It = new(Values.It);

    public static readonly SupportedLocales Ja = new(Values.Ja);

    public static readonly SupportedLocales Ka = new(Values.Ka);

    public static readonly SupportedLocales Kk = new(Values.Kk);

    public static readonly SupportedLocales Kn = new(Values.Kn);

    public static readonly SupportedLocales Ko = new(Values.Ko);

    public static readonly SupportedLocales Lt = new(Values.Lt);

    public static readonly SupportedLocales Lv = new(Values.Lv);

    public static readonly SupportedLocales Mk = new(Values.Mk);

    public static readonly SupportedLocales Ml = new(Values.Ml);

    public static readonly SupportedLocales Mn = new(Values.Mn);

    public static readonly SupportedLocales Mr = new(Values.Mr);

    public static readonly SupportedLocales Ms = new(Values.Ms);

    public static readonly SupportedLocales My = new(Values.My);

    public static readonly SupportedLocales Nb = new(Values.Nb);

    public static readonly SupportedLocales Nl = new(Values.Nl);

    public static readonly SupportedLocales Nn = new(Values.Nn);

    public static readonly SupportedLocales No = new(Values.No);

    public static readonly SupportedLocales Pa = new(Values.Pa);

    public static readonly SupportedLocales Pl = new(Values.Pl);

    public static readonly SupportedLocales Pt = new(Values.Pt);

    public static readonly SupportedLocales PtBr = new(Values.PtBr);

    public static readonly SupportedLocales PtPt = new(Values.PtPt);

    public static readonly SupportedLocales Ro = new(Values.Ro);

    public static readonly SupportedLocales Ru = new(Values.Ru);

    public static readonly SupportedLocales Sk = new(Values.Sk);

    public static readonly SupportedLocales Sl = new(Values.Sl);

    public static readonly SupportedLocales So = new(Values.So);

    public static readonly SupportedLocales Sq = new(Values.Sq);

    public static readonly SupportedLocales Sr = new(Values.Sr);

    public static readonly SupportedLocales Sv = new(Values.Sv);

    public static readonly SupportedLocales Sw = new(Values.Sw);

    public static readonly SupportedLocales Ta = new(Values.Ta);

    public static readonly SupportedLocales Te = new(Values.Te);

    public static readonly SupportedLocales Th = new(Values.Th);

    public static readonly SupportedLocales Tl = new(Values.Tl);

    public static readonly SupportedLocales Tr = new(Values.Tr);

    public static readonly SupportedLocales Uk = new(Values.Uk);

    public static readonly SupportedLocales Ur = new(Values.Ur);

    public static readonly SupportedLocales Vi = new(Values.Vi);

    public static readonly SupportedLocales Zgh = new(Values.Zgh);

    public static readonly SupportedLocales ZhCn = new(Values.ZhCn);

    public static readonly SupportedLocales ZhHk = new(Values.ZhHk);

    public static readonly SupportedLocales ZhMo = new(Values.ZhMo);

    public static readonly SupportedLocales ZhTw = new(Values.ZhTw);

    public SupportedLocales(string value)
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
    public static SupportedLocales FromCustom(string value)
    {
        return new SupportedLocales(value);
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

    public static bool operator ==(SupportedLocales value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SupportedLocales value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SupportedLocales value) => value.Value;

    public static explicit operator SupportedLocales(string value) => new(value);

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
