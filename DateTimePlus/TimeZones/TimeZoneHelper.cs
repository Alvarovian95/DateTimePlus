using System;

namespace DateTimePlus.TimeZones;

public static class TimeZoneHelper
{
    public static DateTimeOffset ConvertToTimeZone(
        DateTimeOffset dateTime,
        TimeZoneInfo destinationTimeZone)
    {
        return TimeZoneInfo.ConvertTime(dateTime, destinationTimeZone);
    }

    public static DateTimeOffset ConvertToTimeZone(
        DateTimeOffset dateTime,
        string destinationTimeZoneId)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
        return TimeZoneInfo.ConvertTime(dateTime, timeZone);
    }
}
