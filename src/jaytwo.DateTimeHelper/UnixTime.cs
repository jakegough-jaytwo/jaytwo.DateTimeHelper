using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.DateTimeHelper
{
    public static class UnixTime
    {
        public static DateTime Origin { get; } = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTimeFromMilliseconds(long value)
        {
            return Origin.AddMilliseconds(value);
        }

        public static DateTime ToDateTimeFromUnixTimeSeconds(long value)
        {
            return Origin.AddSeconds(value);
        }

        public static DateTimeOffset ToDateTimeOffsetFromMilliseconds(long value)
        {
            return new DateTimeOffset(ToDateTimeFromMilliseconds(value));
        }

        public static DateTimeOffset ToDateTimeOffsetFromUnixTimeSeconds(long value)
        {
            return new DateTimeOffset(ToDateTimeFromUnixTimeSeconds(value));
        }

        public static long ToUnixTimeSeconds(DateTime value)
        {
            return (long)value.ToUniversalTime().Subtract(Origin).TotalSeconds;
        }

        public static long ToUnixTimeMilliseconds(DateTime value)
        {
            return (long)value.ToUniversalTime().Subtract(Origin).TotalMilliseconds;
        }

        public static long ToUnixTimeSeconds(DateTimeOffset value)
        {
            return (long)value.ToUniversalTime().Subtract(Origin).TotalSeconds;
        }

        public static long ToUnixTimeMilliseconds(DateTimeOffset value)
        {
            return (long)value.ToUniversalTime().Subtract(Origin).TotalMilliseconds;
        }
    }
}
