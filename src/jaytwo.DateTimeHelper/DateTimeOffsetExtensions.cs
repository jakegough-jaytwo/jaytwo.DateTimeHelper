using System;
using System.Globalization;
using System.Linq;

namespace jaytwo.DateTimeHelper
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset AddWeekdays(this DateTimeOffset value, int weekdaysToAdd)
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

        public static DateTimeOffset AsLocal(this DateTimeOffset value)
        {
            return new DateTimeOffset(value.DateTime.AsLocal());
        }

        public static DateTimeOffset AsUtc(this DateTimeOffset value)
        {
            return new DateTimeOffset(value.DateTime.AsUtc());
        }

        public static bool IsSameDayAs(this DateTimeOffset value, DateTimeOffset other)
        {
            if (value.Offset != other.Offset)
            {
                throw new InvalidOperationException($"Cannot compare {nameof(DateTimeOffset)} days with different {nameof(DateTimeOffset.Offset)} values.");
            }

            return value.Date == other.Date;
        }

        public static bool IsSameDayOrAfter(this DateTimeOffset value, DateTimeOffset other)
        {
            return IsSameDayAs(value, other) || IsAfter(value, other);
        }

        public static bool IsSameDayOrBefore(this DateTimeOffset value, DateTimeOffset other)
        {
            return IsSameDayAs(value, other) || IsBefore(value, other);
        }

        public static bool IsBefore(this DateTimeOffset value, DateTimeOffset other)
        {
            return value < other;
        }

        public static bool IsAfter(this DateTimeOffset value, DateTimeOffset other)
        {
            return value > other;
        }

        public static bool IsWeekday(this DateTimeOffset value)
        {
            return !IsWeekend(value);
        }

        public static bool IsWeekend(this DateTimeOffset value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        public static string ToIso8601String(this DateTimeOffset value)
        {
            // "o" is the Round-trip Format Specifier
            //  "takes advantage of the three ways that ISO 8601 represents time zone information to preserve the Kind property of DateTime values"

            return value.ToString("o", CultureInfo.InvariantCulture);
        }

        public static long ToLdapTime(this DateTimeOffset value)
        {
            return LdapTime.ToLdapTime(value);
        }

        public static string ToSortableString(this DateTimeOffset value)
        {
            return value.ToString("s", CultureInfo.InvariantCulture);
        }

#if NETFRAMEWORK
        // shims for .NET Framework
        public static long ToUnixTimeSeconds(this DateTimeOffset value) => UnixTime.ToUnixTimeSeconds(value);

        public static long ToUnixTimeMilliseconds(this DateTimeOffset value) => UnixTime.ToUnixTimeMilliseconds(value);
#endif

        public static DateTimeOffset TruncateToSecond(this DateTimeOffset value)
        {
            return new DateTimeOffset(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, 0, value.Offset);
        }

        public static DateTimeOffset TruncateToMinute(this DateTimeOffset value)
        {
            return new DateTimeOffset(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, 0, value.Offset);
        }
    }
}
