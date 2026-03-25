using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PromptLanguageEnum.PromptLanguageEnumSerializer))]
[Serializable]
public readonly record struct PromptLanguageEnum : IStringEnum
{
    public static readonly PromptLanguageEnum Am = new(Values.Am);

    public static readonly PromptLanguageEnum Ar = new(Values.Ar);

    public static readonly PromptLanguageEnum ArEg = new(Values.ArEg);

    public static readonly PromptLanguageEnum ArSa = new(Values.ArSa);

    public static readonly PromptLanguageEnum Az = new(Values.Az);

    public static readonly PromptLanguageEnum Bg = new(Values.Bg);

    public static readonly PromptLanguageEnum Bn = new(Values.Bn);

    public static readonly PromptLanguageEnum Bs = new(Values.Bs);

    public static readonly PromptLanguageEnum CaEs = new(Values.CaEs);

    public static readonly PromptLanguageEnum Cnr = new(Values.Cnr);

    public static readonly PromptLanguageEnum Cs = new(Values.Cs);

    public static readonly PromptLanguageEnum Cy = new(Values.Cy);

    public static readonly PromptLanguageEnum Da = new(Values.Da);

    public static readonly PromptLanguageEnum De = new(Values.De);

    public static readonly PromptLanguageEnum El = new(Values.El);

    public static readonly PromptLanguageEnum En = new(Values.En);

    public static readonly PromptLanguageEnum EnCa = new(Values.EnCa);

    public static readonly PromptLanguageEnum Es = new(Values.Es);

    public static readonly PromptLanguageEnum Es419 = new(Values.Es419);

    public static readonly PromptLanguageEnum EsAr = new(Values.EsAr);

    public static readonly PromptLanguageEnum EsMx = new(Values.EsMx);

    public static readonly PromptLanguageEnum Et = new(Values.Et);

    public static readonly PromptLanguageEnum EuEs = new(Values.EuEs);

    public static readonly PromptLanguageEnum Fa = new(Values.Fa);

    public static readonly PromptLanguageEnum Fi = new(Values.Fi);

    public static readonly PromptLanguageEnum Fr = new(Values.Fr);

    public static readonly PromptLanguageEnum FrCa = new(Values.FrCa);

    public static readonly PromptLanguageEnum FrFr = new(Values.FrFr);

    public static readonly PromptLanguageEnum GlEs = new(Values.GlEs);

    public static readonly PromptLanguageEnum Gu = new(Values.Gu);

    public static readonly PromptLanguageEnum He = new(Values.He);

    public static readonly PromptLanguageEnum Hi = new(Values.Hi);

    public static readonly PromptLanguageEnum Hr = new(Values.Hr);

    public static readonly PromptLanguageEnum Hu = new(Values.Hu);

    public static readonly PromptLanguageEnum Hy = new(Values.Hy);

    public static readonly PromptLanguageEnum Id = new(Values.Id);

    public static readonly PromptLanguageEnum Is = new(Values.Is);

    public static readonly PromptLanguageEnum It = new(Values.It);

    public static readonly PromptLanguageEnum Ja = new(Values.Ja);

    public static readonly PromptLanguageEnum Ka = new(Values.Ka);

    public static readonly PromptLanguageEnum Kk = new(Values.Kk);

    public static readonly PromptLanguageEnum Kn = new(Values.Kn);

    public static readonly PromptLanguageEnum Ko = new(Values.Ko);

    public static readonly PromptLanguageEnum Lt = new(Values.Lt);

    public static readonly PromptLanguageEnum Lv = new(Values.Lv);

    public static readonly PromptLanguageEnum Mk = new(Values.Mk);

    public static readonly PromptLanguageEnum Ml = new(Values.Ml);

    public static readonly PromptLanguageEnum Mn = new(Values.Mn);

    public static readonly PromptLanguageEnum Mr = new(Values.Mr);

    public static readonly PromptLanguageEnum Ms = new(Values.Ms);

    public static readonly PromptLanguageEnum My = new(Values.My);

    public static readonly PromptLanguageEnum Nb = new(Values.Nb);

    public static readonly PromptLanguageEnum Nl = new(Values.Nl);

    public static readonly PromptLanguageEnum Nn = new(Values.Nn);

    public static readonly PromptLanguageEnum No = new(Values.No);

    public static readonly PromptLanguageEnum Pa = new(Values.Pa);

    public static readonly PromptLanguageEnum Pl = new(Values.Pl);

    public static readonly PromptLanguageEnum Pt = new(Values.Pt);

    public static readonly PromptLanguageEnum PtBr = new(Values.PtBr);

    public static readonly PromptLanguageEnum PtPt = new(Values.PtPt);

    public static readonly PromptLanguageEnum Ro = new(Values.Ro);

    public static readonly PromptLanguageEnum Ru = new(Values.Ru);

    public static readonly PromptLanguageEnum Sk = new(Values.Sk);

    public static readonly PromptLanguageEnum Sl = new(Values.Sl);

    public static readonly PromptLanguageEnum So = new(Values.So);

    public static readonly PromptLanguageEnum Sq = new(Values.Sq);

    public static readonly PromptLanguageEnum Sr = new(Values.Sr);

    public static readonly PromptLanguageEnum Sv = new(Values.Sv);

    public static readonly PromptLanguageEnum Sw = new(Values.Sw);

    public static readonly PromptLanguageEnum Ta = new(Values.Ta);

    public static readonly PromptLanguageEnum Te = new(Values.Te);

    public static readonly PromptLanguageEnum Th = new(Values.Th);

    public static readonly PromptLanguageEnum Tl = new(Values.Tl);

    public static readonly PromptLanguageEnum Tr = new(Values.Tr);

    public static readonly PromptLanguageEnum Uk = new(Values.Uk);

    public static readonly PromptLanguageEnum Ur = new(Values.Ur);

    public static readonly PromptLanguageEnum Vi = new(Values.Vi);

    public static readonly PromptLanguageEnum Zgh = new(Values.Zgh);

    public static readonly PromptLanguageEnum ZhCn = new(Values.ZhCn);

    public static readonly PromptLanguageEnum ZhHk = new(Values.ZhHk);

    public static readonly PromptLanguageEnum ZhMo = new(Values.ZhMo);

    public static readonly PromptLanguageEnum ZhTw = new(Values.ZhTw);

    public PromptLanguageEnum(string value)
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
    public static PromptLanguageEnum FromCustom(string value)
    {
        return new PromptLanguageEnum(value);
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

    public static bool operator ==(PromptLanguageEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PromptLanguageEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PromptLanguageEnum value) => value.Value;

    public static explicit operator PromptLanguageEnum(string value) => new(value);

    internal class PromptLanguageEnumSerializer : JsonConverter<PromptLanguageEnum>
    {
        public override PromptLanguageEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new PromptLanguageEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptLanguageEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

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
