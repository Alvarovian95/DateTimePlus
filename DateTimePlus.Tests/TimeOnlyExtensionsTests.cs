using Xunit;
using DateTimePlus.Extensions;
using System;

namespace DateTimePlus.Tests
{
    public class TimeOnlyExtensionsTests
    {
        [Fact]
        public void ToDateTime_CombineTimeAndDate_ReturnsCorrectDateTime()
        {
            var date = new DateOnly(2026, 1, 14);
            var time = new TimeOnly(15, 30); // 15:30
            var result = time.ToDateTime(date);

            Assert.Equal(new DateTime(2026, 1, 14, 15, 30, 0), result);
        }
    }
}
