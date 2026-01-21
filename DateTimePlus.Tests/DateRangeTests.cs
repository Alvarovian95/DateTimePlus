using DateTimePlus.Extensions;

namespace DateTimePlus.Tests
{
    public class DateRangeTests
    {
        [Fact]
        public void Days_ReturnsAllDaysInRange()
        {
            var start = new DateOnly(2026, 1, 14);
            var end = new DateOnly(2026, 1, 16);
            var range = new DateRange(start, end);

            var days = range.Days().ToList();
            Assert.Equal(3, days.Count);
            Assert.Contains(new DateOnly(2026, 1, 15), days);
        }

        [Fact]
        public void BusinessDays_SkipsWeekends()
        {
            var start = new DateOnly(2026, 1, 16); // viernes
            var end = new DateOnly(2026, 1, 19);   // lunes
            var range = new DateRange(start, end);

            var businessDays = range.BusinessDays().ToList();
            Assert.Equal(2, businessDays.Count); // viernes y lunes
            Assert.DoesNotContain(new DateOnly(2026, 1, 17), businessDays); // sábado
            Assert.DoesNotContain(new DateOnly(2026, 1, 18), businessDays); // domingo
        }

        [Fact]
        public void Contains_ReturnsTrueIfDateInRange()
        {
            var range = new DateRange(new DateOnly(2026, 1, 14), new DateOnly(2026, 1, 16));
            Assert.True(range.Contains(new DateOnly(2026, 1, 15)));
            Assert.False(range.Contains(new DateOnly(2026, 1, 17)));
        }
    }
}
