using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi;

/// <summary>
/// A JSON date converter that reads both ISO 8601 and epoch (seconds) dates.
/// </summary>
internal class FlexibleDateTimeConverter : JsonConverter<DateTime?>
{
    private static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return Add(Epoch, TimeSpan.FromSeconds(reader.GetInt64()));
            case JsonTokenType.String:
                // Prefer STJ's ISO 8601 reader; fall back to a lenient parse for other
                // formats. An unparseable value yields null rather than throwing and
                // failing the entire enclosing object's deserialization.
                if (reader.TryGetDateTime(out var iso))
                    return iso;
                return DateTime.TryParse(reader.GetString(), CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind, out var parsed) ? parsed : null;
            default:
                return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private static DateTime Add(DateTime time, TimeSpan timespan)
    {
        if (timespan == TimeSpan.Zero)
            return time;

        if (timespan > TimeSpan.Zero && DateTime.MaxValue - time <= timespan)
            return GetMaxValue(time.Kind);

        if (timespan < TimeSpan.Zero && DateTime.MinValue - time >= timespan)
            return GetMinValue(time.Kind);

        return time + timespan;
    }

    private static DateTime GetMaxValue(DateTimeKind kind)
    {
        return new DateTime(DateTime.MaxValue.Ticks,
            kind == DateTimeKind.Unspecified ? DateTimeKind.Utc : kind);
    }

    private static DateTime GetMinValue(DateTimeKind kind)
    {
        return new DateTime(DateTime.MinValue.Ticks,
            kind == DateTimeKind.Unspecified ? DateTimeKind.Utc : kind);
    }
}
