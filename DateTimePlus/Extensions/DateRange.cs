using System;
using System.Collections.Generic;

namespace DateTimePlus.Extensions
{
    public class DateRange
    {
        public DateOnly Start { get; }
        public DateOnly End { get; }

        public DateRange(DateOnly start, DateOnly end)
        {
            if (end < start) throw new ArgumentException("End date must be after start date");
            Start = start;
            End = end;
        }

        public IEnumerable<DateOnly> Days()
        {
            for (var day = Start; day <= End; day = day.AddDays(1))
                yield return day;
        }

        public IEnumerable<DateOnly> BusinessDays()
        {
            foreach (var day in Days())
                if (!day.IsWeekend())
                    yield return day;
        }

        public bool Contains(DateOnly date) => date >= Start && date <= End;
    }
}
