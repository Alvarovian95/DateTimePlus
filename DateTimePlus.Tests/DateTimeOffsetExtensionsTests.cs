using System;
using Xunit;
using DateTimePlus.Extensions;
using DateTimePlus.TimeZones;

namespace DateTimePlus.Tests
{
    public class DateTimeOffsetExtensionsTests
    {
        [Fact]
        public void TestStartOfDay()
        {
            var dto = new DateTimeOffset(2026, 1, 21, 15, 30, 45, TimeSpan.FromHours(1));
            var start = dto.StartOfDay();

            Assert.Equal(0, start.Hour);
            Assert.Equal(0, start.Minute);
            Assert.Equal(0, start.Second);
            Assert.Equal(dto.Offset, start.Offset);
        }

        [Fact]
        public void TestEndOfDay()
        {
            var dto = new DateTimeOffset(2026, 1, 21, 10, 20, 30, TimeSpan.FromHours(2));
            var end = dto.EndOfDay();

            Assert.Equal(23, end.Hour);
            Assert.Equal(59, end.Minute);
            Assert.Equal(59, end.Second);
            Assert.Equal(999, end.Millisecond);
            Assert.Equal(dto.Offset, end.Offset);
        }

        [Fact]
        public void TestIsToday()
        {
            var now = DateTimeOffset.UtcNow;
            var dto = now;

            Assert.True(dto.IsToday());
        }

        [Fact]
        public void TestIsPast()
        {
            var past = DateTimeOffset.UtcNow.AddDays(-1);

            Assert.True(past.IsPast());
        }

        [Fact]
        public void TestIsFuture()
        {
            var future = DateTimeOffset.UtcNow.AddDays(1);

            Assert.True(future.IsFuture());
        }

        [Fact]
        public void TestConvertToTimeZone()
        {
            var utc = new DateTimeOffset(2026, 1, 21, 12, 0, 0, TimeSpan.Zero);
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var converted = TimeZoneHelper.ConvertToTimeZone(utc, tz);

            Assert.Equal(tz.GetUtcOffset(converted.DateTime), converted.Offset);
        }

        [Fact]
        public void TestStartOfDayInTimeZone()
        {
            var utc = new DateTimeOffset(2026, 1, 21, 22, 0, 0, TimeSpan.Zero);
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var start = utc.StartOfDayInTimeZone(tz);

            Assert.Equal(0, start.Hour);
            Assert.Equal(0, start.Minute);
            Assert.Equal(tz.BaseUtcOffset, start.Offset);
        }
    }
}
