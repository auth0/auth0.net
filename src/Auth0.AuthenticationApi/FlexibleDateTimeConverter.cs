using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// A JSON date converter that reads both ISO 8601 and epoch dates.
    /// </summary>
    internal class FlexibleDateTimeConverter : IsoDateTimeConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;

            return reader.TokenType == JsonToken.Integer
                ? Add(Epoch, TimeSpan.FromSeconds((long)reader.Value))
                : reader.Value;
        }

        /// <summary>
        /// Add a DateTime and a TimeSpan.
        /// The maximum time is DateTime.MaxTime.  It is not an error if time + timespan > MaxTime.
        /// Just return MaxTime.
        /// </summary>
        /// <param name="time">Initial <see cref="DateTime"/> value.</param>
        /// <param name="timespan"><see cref="TimeSpan"/> to add.</param>
        /// <returns><see cref="DateTime"/> as the sum of time and timespan.</returns>
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

        /// <summary>
        /// Gets the Maximum value for a DateTime specifying kind.
        /// </summary>
        /// <param name="kind">DateTimeKind to use.</param>
        /// <returns>DateTime of specified kind.</returns>
        private static DateTime GetMaxValue(DateTimeKind kind)
        {
            return new DateTime(DateTime.MaxValue.Ticks,
                kind == DateTimeKind.Unspecified ? DateTimeKind.Utc : kind);
        }

        /// <summary>
        /// Gets the Minimum value for a DateTime specifying kind.
        /// </summary>
        /// <param name="kind">DateTimeKind to use.</param>
        /// <returns>DateTime of specified kind.</returns>
        private static DateTime GetMinValue(DateTimeKind kind)
        {
            return new DateTime(DateTime.MinValue.Ticks,
                kind == DateTimeKind.Unspecified ? DateTimeKind.Utc : kind);
        }
    }
}
