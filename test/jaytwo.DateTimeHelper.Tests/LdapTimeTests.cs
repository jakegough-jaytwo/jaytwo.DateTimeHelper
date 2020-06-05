using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.DateTimeHelper.Tests
{
    public class LdapTimeTests
    {
        [Fact]
        public void DateTime_ToLdapTime()
        {
            // http://www.epochconverter.com/epoch/ldap-timestamp.php

            // arrange
            var date = new DateTime(2015, 1, 25, 1, 12, 25, 123, DateTimeKind.Utc);

            // act
            var actual = LdapTime.ToLdapTime(date);

            //assert
            Assert.Equal(130666219451230000, actual);
        }

        [Fact]
        public void DateTimeOffset_ToLdapTime()
        {
            // http://www.epochconverter.com/epoch/ldap-timestamp.php

            // arrange
            var date = new DateTimeOffset(2015, 1, 25, 1, 12, 25, 123, TimeSpan.Zero);

            // act
            var actual = LdapTime.ToLdapTime(date);

            //assert
            Assert.Equal(130666219451230000, actual);
        }
    }
}
