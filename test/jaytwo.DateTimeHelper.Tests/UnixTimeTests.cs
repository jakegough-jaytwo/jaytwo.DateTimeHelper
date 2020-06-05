using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.DateTimeHelper.Tests
{
    public class UnixTimeTests
    {
        [Fact]
        public void ToUnixTimeSeconds_DateTime_UtcNow()
        {
            // arrange
            var now = DateTime.UtcNow;
            var expected = new DateTimeOffset(now).ToUnixTimeSeconds();

            // act
            var actual = UnixTime.ToUnixTimeSeconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeSeconds_DateTimeOffset_UtcNow()
        {
            // arrange
            var now = DateTimeOffset.UtcNow;
            var expected = now.ToUnixTimeSeconds();

            // act
            var actual = UnixTime.ToUnixTimeSeconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeMilliseconds_DateTime_UtcNow()
        {
            // arrange
            var now = DateTime.UtcNow;
            var expected = new DateTimeOffset(now).ToUnixTimeMilliseconds();

            // act
            var actual = UnixTime.ToUnixTimeMilliseconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeMilliseconds_DateTimeOffset_UtcNow()
        {
            // arrange
            var now = DateTimeOffset.UtcNow;
            var expected = now.ToUnixTimeMilliseconds();

            // act
            var actual = UnixTime.ToUnixTimeMilliseconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeSeconds_DateTime_Now()
        {
            // arrange
            var now = DateTime.Now;
            var expected = new DateTimeOffset(now).ToUnixTimeSeconds();

            // act
            var actual = UnixTime.ToUnixTimeSeconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeSeconds_DateTimeOffset_Now()
        {
            // arrange
            var now = DateTimeOffset.Now;
            var expected = now.ToUnixTimeSeconds();

            // act
            var actual = UnixTime.ToUnixTimeSeconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeMilliseconds_DateTime_Now()
        {
            // arrange
            var now = DateTime.Now;
            var expected = new DateTimeOffset(now).ToUnixTimeMilliseconds();

            // act
            var actual = UnixTime.ToUnixTimeMilliseconds(now);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUnixTimeMilliseconds_DateTimeOffset_Now()
        {
            // arrange
            var now = DateTimeOffset.Now;
            var expected = now.ToUnixTimeMilliseconds();

            // act
            var actual = UnixTime.ToUnixTimeMilliseconds(now);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
