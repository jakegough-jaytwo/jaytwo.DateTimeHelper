using System;
using System.Collections.Generic;
using Xunit;

namespace jaytwo.DateTimeHelper.Tests
{
    public class DateTimeOffsetExtensionsTests
    {
        [Fact]
        public void SubtractDays()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 8));

            // act
            var actual = date.SubtractDays(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractHours()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 8, 23, 0, 0));

            // act
            var actual = date.SubtractHours(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractMilliseconds()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 8, 23, 59, 59, 999));

            // act
            var actual = date.SubtractMilliseconds(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractMinutes()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 8, 23, 59, 0));

            // act
            var actual = date.SubtractMinutes(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractMonths()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 5, 9));

            // act
            var actual = date.SubtractMonths(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractSeconds()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 8, 23, 59, 59));

            // act
            var actual = date.SubtractSeconds(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractTicks()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));

            // act
            var actual = date.SubtractTicks(1);

            // assert
            Assert.Equal(date.Ticks - 1, actual.Ticks);
        }

        [Fact]
        public void SubtractWeekdays()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2020, 6, 9));
            var expected = new DateTimeOffset(new DateTime(2020, 6, 2));

            // act
            var actual = date.SubtractWeekdays(5);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2020-05-15", 0, "2020-05-15")] // friday
        [InlineData("2020-05-15", 1, "2020-05-18")]
        [InlineData("2020-05-15", 2, "2020-05-19")]
        [InlineData("2020-05-15", 3, "2020-05-20")]
        [InlineData("2020-05-15", 4, "2020-05-21")]
        [InlineData("2020-05-15", 5, "2020-05-22")]
        [InlineData("2020-05-15", 10, "2020-05-29")]
        [InlineData("2020-05-15", -5, "2020-05-08")]
        [InlineData("2020-05-15", -10, "2020-05-01")]
        public void AddWeekdays(string startDateString, int weekdays, string expectedDateString)
        {
            // arrange
            var startDate = new DateTimeOffset(DateTime.Parse(startDateString), TimeSpan.FromHours(7));
            var expectedDate = new DateTimeOffset(DateTime.Parse(expectedDateString), TimeSpan.FromHours(7));

            // act
            var actual = startDate.AddWeekdays(weekdays);

            // assert
            Assert.Equal(expectedDate, actual);
        }

        [Fact]
        public void AsLocal()
        {
            // arrange
            var time = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified));
            var expected = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Local));

            // act
            var actual = time.AsLocal();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AsUtc()
        {
            // arrange
            var time = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified));
            var expected = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Utc));

            // act
            var actual = time.AsUtc();

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2020-05-20", "2020-05-20", true)]
        [InlineData("2020-05-20", "2020-05-19", false)]
        [InlineData("2020-05-19", "2020-05-20", false)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 00:00:01", true)]
        [InlineData("2020-05-20 00:00:01", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 23:59:59", true)]
        [InlineData("2020-05-20 23:59:59", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-19 23:59:59", false)]
        [InlineData("2020-05-19 23:59:59", "2020-05-20 00:00:00", false)]
        public void IsSameDayAs(string a, string b, bool expected)
        {
            // arrange
            var aDate = DateTimeOffset.Parse(a);
            var bDate = DateTimeOffset.Parse(b);

            // act
            var a_to_b = aDate.IsSameDayAs(bDate);
            var b_to_a = bDate.IsSameDayAs(aDate);

            // assert
            Assert.Equal(expected, a_to_b);
            Assert.Equal(expected, b_to_a);
        }

        [Theory]
        [InlineData("2020-05-20", "2020-05-20", true)]
        [InlineData("2020-05-20", "2020-05-19", true)]
        [InlineData("2020-05-19", "2020-05-20", false)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 00:00:01", true)]
        [InlineData("2020-05-20 00:00:01", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 23:59:59", true)]
        [InlineData("2020-05-20 23:59:59", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-19 23:59:59", true)]
        [InlineData("2020-05-19 23:59:59", "2020-05-20 00:00:00", false)]
        public void IsSameDayOrAfter(string a, string b, bool expected)
        {
            // arrange
            var aDate = DateTimeOffset.Parse(a);
            var bDate = DateTimeOffset.Parse(b);

            // act
            var actual = aDate.IsSameDayOrAfter(bDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2020-05-20", "2020-05-20", true)]
        [InlineData("2020-05-20", "2020-05-19", false)]
        [InlineData("2020-05-19", "2020-05-20", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 00:00:01", true)]
        [InlineData("2020-05-20 00:00:01", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 23:59:59", true)]
        [InlineData("2020-05-20 23:59:59", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-19 23:59:59", false)]
        [InlineData("2020-05-19 23:59:59", "2020-05-20 00:00:00", true)]
        public void IsSameDayOrBefore(string a, string b, bool expected)
        {
            // arrange
            var aDate = DateTimeOffset.Parse(a);
            var bDate = DateTimeOffset.Parse(b);

            // act
            var actual = aDate.IsSameDayOrBefore(bDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2020-05-20", "2020-05-20", false)]
        [InlineData("2020-05-20", "2020-05-19", true)]
        [InlineData("2020-05-19", "2020-05-20", false)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 00:00:01", false)]
        [InlineData("2020-05-20 00:00:01", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 23:59:59", false)]
        [InlineData("2020-05-20 23:59:59", "2020-05-20 00:00:00", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-19 23:59:59", true)]
        [InlineData("2020-05-19 23:59:59", "2020-05-20 00:00:00", false)]
        public void IsAfter(string a, string b, bool expected)
        {
            // arrange
            var aDate = DateTimeOffset.Parse(a);
            var bDate = DateTimeOffset.Parse(b);

            // act
            var actual = aDate.IsAfter(bDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2020-05-20", "2020-05-20", false)]
        [InlineData("2020-05-20", "2020-05-19", false)]
        [InlineData("2020-05-19", "2020-05-20", true)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 00:00:01", true)]
        [InlineData("2020-05-20 00:00:01", "2020-05-20 00:00:00", false)]
        [InlineData("2020-05-20 00:00:00", "2020-05-20 23:59:59", true)]
        [InlineData("2020-05-20 23:59:59", "2020-05-20 00:00:00", false)]
        [InlineData("2020-05-20 00:00:00", "2020-05-19 23:59:59", false)]
        [InlineData("2020-05-19 23:59:59", "2020-05-20 00:00:00", true)]
        public void IsBefore(string a, string b, bool expected)
        {
            // arrange
            var aDate = DateTimeOffset.Parse(a);
            var bDate = DateTimeOffset.Parse(b);

            // act
            var actual = aDate.IsBefore(bDate);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(DayOfWeek.Sunday, false)]
        [InlineData(DayOfWeek.Monday, true)]
        [InlineData(DayOfWeek.Tuesday, true)]
        [InlineData(DayOfWeek.Wednesday, true)]
        [InlineData(DayOfWeek.Thursday, true)]
        [InlineData(DayOfWeek.Friday, true)]
        [InlineData(DayOfWeek.Saturday, false)]
        public void IsWeekday(DayOfWeek dayOfWeek, bool expected)
        {
            // arrange
            var knownSunday = new DateTimeOffset(new DateTime(2020, 5, 31, 0, 0, 0));
            var time = knownSunday.AddDays((int)dayOfWeek);

            // act
            var actual = time.IsWeekday();

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(DayOfWeek.Sunday, true)]
        [InlineData(DayOfWeek.Monday, false)]
        [InlineData(DayOfWeek.Tuesday, false)]
        [InlineData(DayOfWeek.Wednesday, false)]
        [InlineData(DayOfWeek.Thursday, false)]
        [InlineData(DayOfWeek.Friday, false)]
        [InlineData(DayOfWeek.Saturday, true)]
        public void IsWeekend(DayOfWeek dayOfWeek, bool expected)
        {
            // arrange
            var knownSunday = new DateTimeOffset(new DateTime(2020, 5, 31, 0, 0, 0));
            var time = knownSunday.AddDays((int)dayOfWeek);

            // act
            var actual = time.IsWeekend();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToIso8601String_Zero_Offset()
        {
            // arrange
            var date = new DateTimeOffset(2015, 1, 25, 1, 12, 25, 123, TimeSpan.Zero);
            var expected = $"2015-01-25T01:12:25.1230000{(date.Offset >= TimeSpan.Zero ? "+" : string.Empty)}{date.Offset.Hours:00}:{date.Offset.Minutes:00}";

            // act
            var actual = date.ToIso8601String();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToIso8601String_Positive_Offset()
        {
            // arrange
            var date = new DateTimeOffset(2015, 1, 25, 1, 12, 25, 123, TimeSpan.FromHours(5));
            var expected = $"2015-01-25T01:12:25.1230000{(date.Offset >= TimeSpan.Zero ? "+" : string.Empty)}{date.Offset.Hours:00}:{date.Offset.Minutes:00}";

            // act
            var actual = date.ToIso8601String();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToIso8601String_Negative_Offset()
        {
            // arrange
            var date = new DateTimeOffset(2015, 1, 25, 1, 12, 25, 123, TimeSpan.FromHours(-5));
            var expected = $"2015-01-25T01:12:25.1230000{(date.Offset >= TimeSpan.Zero ? "+" : string.Empty)}{date.Offset.Hours:00}:{date.Offset.Minutes:00}";

            // act
            var actual = date.ToIso8601String();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToLdapTime()
        {
            // http://www.epochconverter.com/epoch/ldap-timestamp.php

            // arrange
            var date = new DateTimeOffset(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc));

            // act
            var actual = date.ToLdapTime();

            //assert
            Assert.Equal(130666219451230000, actual);
        }

        [Fact]
        public void ToSortableString()
        {
            // arrange
            var date = new DateTimeOffset(new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc));

            // act
            var actual = date.ToSortableString();

            //assert
            Assert.Equal("2015-01-25T01:12:25", actual);
        }

        [Fact]
        public void TruncateToMinute()
        {
            // arrange
            var time = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified));
            var expected = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 0, 0, DateTimeKind.Unspecified));

            // act
            var actual = time.TruncateToMinute();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TruncateToSecond()
        {
            // arrange
            var time = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 45, DateTimeKind.Unspecified));
            var expected = new DateTimeOffset(new DateTime(2014, 1, 1, 12, 23, 34, 0, DateTimeKind.Unspecified));

            // act
            var actual = time.TruncateToSecond();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
