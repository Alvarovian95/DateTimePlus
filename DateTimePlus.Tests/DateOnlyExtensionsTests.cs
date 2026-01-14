using Xunit;
using DateTimePlus.Extensions;
using System;

namespace DateTimePlus.Tests
{
    public class DateOnlyExtensionsTests
    {
        [Fact]
        public void TestIsWeekend()
        {
            var saturday = new DateOnly(2026, 1, 17);
            Assert.True(saturday.IsWeekend());

            var monday = new DateOnly(2026, 1, 19);
            Assert.False(monday.IsWeekend());
        }

        [Fact]
        public void TestNextWeekday()
        {
            var saturday = new DateOnly(2026, 1, 17);
            var monday = saturday.NextWeekday();
            Assert.Equal(new DateOnly(2026, 1, 19), monday);
        }

        [Fact]
        public void TestAddBusinessDays()
        {
            var friday = new DateOnly(2026, 1, 16);
            var result = friday.AddBusinessDays(3); // Sábado y domingo se saltan
            Assert.Equal(new DateOnly(2026, 1, 21), result);
        }
    }
}
