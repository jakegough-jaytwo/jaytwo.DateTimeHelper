using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.DateTimeHelper
{
    public static class LdapTime
    {
        // the number of 100-nanosecond intervals that have elapsed since the 0 hour on January 1, 1601
        // 100 nanoseconds = 0.0001 milliseconds
        // 1 milliseconds = 100 nanoseconds * 10000
        // conveniently, 1 tick = 10000 milliseconds

        public static DateTime Origin { get; } = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToLdapTime(DateTime value)
        {
            return value.ToUniversalTime().Subtract(Origin).Ticks;
        }

        public static long ToLdapTime(DateTimeOffset value)
        {
            return value.ToUniversalTime().Subtract(Origin).Ticks;
        }

        public static DateTime ToDateTime(long value)
        {
            return Origin.AddTicks(value);
        }

        public static DateTimeOffset ToDateTimeOffset(long value)
        {
            return new DateTimeOffset(ToDateTime(value));
        }
    }
}
