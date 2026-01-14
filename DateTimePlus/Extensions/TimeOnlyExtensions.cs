using System;

namespace DateTimePlus.Extensions
{
    public static class TimeOnlyExtensions
    {
        public static DateTime ToDateTime(this TimeOnly time, DateOnly date)
            => date.ToDateTime(time);
    }
}
