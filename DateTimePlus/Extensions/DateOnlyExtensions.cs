using System;

namespace DateTimePlus.Extensions
{
    public static class DateOnlyExtensions
    {
        public static DateTime ToDateTime(this DateOnly date)
            => date.ToDateTime(TimeOnly.MinValue);

        public static bool IsWeekend(this DateOnly date)
            => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

        public static DateOnly NextWeekday(this DateOnly date)
        {
            var next = date;
            do { next = next.AddDays(1); } while (next.IsWeekend());
            return next;
        }

        public static DateOnly AddBusinessDays(this DateOnly date, int days)
        {
            var result = date;
            while (days > 0)
            {
                result = result.AddDays(1);
                if (!result.IsWeekend()) days--;
            }
            return result;
        }

        public static int DaysUntil(this DateOnly start, DateOnly end)
            => (end.ToDateTime(TimeOnly.MinValue) - start.ToDateTime(TimeOnly.MinValue)).Days;

        public static int MonthsUntil(this DateOnly start, DateOnly end)
            => (end.Year - start.Year) * 12 + end.Month - start.Month;
    }
}
