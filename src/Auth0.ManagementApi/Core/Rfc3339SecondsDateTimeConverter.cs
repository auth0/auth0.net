using global::System.Globalization;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Core;

/// <summary>
/// Serializes <see cref="DateTime"/> values as RFC 3339 date-times with second
/// precision (no sub-second component) in UTC, e.g. "2026-07-01T00:00:00Z".
///
/// The default <see cref="DateTimeSerializer"/> emits millisecond precision
/// ("2026-07-01T00:00:00.000Z", 24 chars). Some Auth0 endpoints — such as the
/// event-stream redelivery request (<c>date_from</c>/<c>date_to</c>) — declare
/// <c>maxLength: 20</c> and reject sub-second precision with an HTTP 400. Apply
/// this converter to those fields to keep native <see cref="DateTime"/>
/// ergonomics while emitting a spec-compliant 20-character value.
/// </summary>
internal class Rfc3339SecondsDateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return DateTime.Parse(
            reader.GetString()!,
            CultureInfo.InvariantCulture,
            DateTimeStyles.RoundtripKind
        );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(
            value.ToUniversalTime().ToString(Format, CultureInfo.InvariantCulture)
        );
    }
}
