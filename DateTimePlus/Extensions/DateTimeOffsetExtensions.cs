using System;

namespace DateTimePlus.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset StartOfDay(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                0, 0, 0,
                dateTime.Offset);
        }

        public static DateTimeOffset EndOfDay(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                23, 59, 59, 999,
                dateTime.Offset);
        }

        public static bool IsToday(this DateTimeOffset dateTime, DateTimeOffset? reference = null)
        {
            var now = reference ?? DateTimeOffset.UtcNow;
            return dateTime.Date == now.ToOffset(dateTime.Offset).Date;
        }

        public static bool IsPast(this DateTimeOffset dateTime, DateTimeOffset? reference = null)
        {
            return dateTime < (reference ?? DateTimeOffset.UtcNow);
        }

        public static bool IsFuture(this DateTimeOffset dateTime, DateTimeOffset? reference = null)
        {
            return dateTime > (reference ?? DateTimeOffset.UtcNow);
        }

        public static DateTimeOffset StartOfDayInTimeZone(this DateTimeOffset dateTime, TimeZoneInfo timeZone)
        {
            var zoned = TimeZoneInfo.ConvertTime(dateTime, timeZone);

            var start = new DateTime(zoned.Year, zoned.Month, zoned.Day, 0, 0, 0, DateTimeKind.Unspecified);

            var offset = timeZone.GetUtcOffset(start);

            return new DateTimeOffset(start, offset);
        }
    }
}
