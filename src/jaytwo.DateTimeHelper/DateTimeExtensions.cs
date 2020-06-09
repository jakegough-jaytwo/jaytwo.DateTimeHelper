using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace jaytwo.DateTimeHelper
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWeekdays(this DateTime value, int weekdaysToAdd)
        {
            var step = (weekdaysToAdd > 0) ? 1 : -1;
            var weekdaysAdded = 0;
            var result = value;

            while (Math.Abs(weekdaysAdded) < Math.Abs(weekdaysToAdd))
            {
                result = result.AddDays(step);
                weekdaysAdded += step;

                while (!IsWeekday(result))
                {
                    result = result.AddDays(step);
                }
            }

            return result;
        }

        public static DateTime SubtractDays(this DateTime dateTime, double value) => dateTime.AddDays(-value);

        public static DateTime SubtractHours(this DateTime dateTime, double value) => dateTime.AddHours(-value);

        public static DateTime SubtractMilliseconds(this DateTime dateTime, double value) => dateTime.AddMilliseconds(-value);

        public static DateTime SubtractMinutes(this DateTime dateTime, double value) => dateTime.AddMinutes(-value);

        public static DateTime SubtractMonths(this DateTime dateTime, int value) => dateTime.AddMonths(-value);

        public static DateTime SubtractSeconds(this DateTime dateTime, double value) => dateTime.AddSeconds(-value);

        public static DateTime SubtractTicks(this DateTime dateTime, long value) => dateTime.AddTicks(-value);

        public static DateTime SubtractWeekdays(this DateTime dateTime, int value) => dateTime.AddWeekdays(-value);

        public static DateTime AsLocal(this DateTime value)
        {
            return DateTime.SpecifyKind(value, DateTimeKind.Local);
        }

        public static DateTime AsUtc(this DateTime value)
        {
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public static bool IsSameDayAs(this DateTime value, DateTime other)
        {
            if (value.Kind != other.Kind)
            {
                throw new InvalidOperationException($"Cannot compare {nameof(DateTime)} days with different {nameof(DateTime.Kind)} values.");
            }

            return value.Date == other.Date;
        }

        public static bool IsSameDayOrAfter(this DateTime value, DateTime other)
        {
            return IsSameDayAs(value, other) || IsAfter(value, other);
        }

        public static bool IsSameDayOrBefore(this DateTime value, DateTime other)
        {
            return IsSameDayAs(value, other) || IsBefore(value, other);
        }

        public static bool IsAfter(this DateTime value, DateTime other)
        {
            return value > other;
        }

        public static bool IsBefore(this DateTime value, DateTime other)
        {
            return value < other;
        }

        public static bool IsWeekday(this DateTime value)
        {
            return !IsWeekend(value);
        }

        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        public static string ToIso8601String(this DateTime value)
        {
            // "o" is the Round-trip Format Specifier
            //  "takes advantage of the three ways that ISO 8601 represents time zone information to preserve the Kind property of DateTime values"

            return value.ToString("o", CultureInfo.InvariantCulture);
        }

        public static long ToLdapTime(this DateTime value)
        {
            return LdapTime.ToLdapTime(value);
        }

        public static string ToSortableString(this DateTime value)
        {
            return value.ToString("s", CultureInfo.InvariantCulture);
        }

        public static long ToUnixTimeSeconds(this DateTime value)
        {
            return UnixTime.ToUnixTimeSeconds(value);
        }

        public static long ToUnixTimeMilliseconds(this DateTime value)
        {
            return UnixTime.ToUnixTimeMilliseconds(value);
        }

        public static DateTime TruncateToMinute(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, 0, value.Kind);
        }

        public static DateTime TruncateToSecond(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, 0, value.Kind);
        }
    }
}
