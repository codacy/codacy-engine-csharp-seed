using System;
using Xunit;
using Codacy.Engine.Seed;

namespace Codacy.Engine.Seed.Tests
{
    public class TimeSpanTests
    {
        [Fact]
        public void ParseTest()
        {
            TimeSpan time = TimeSpanHelper.Parse("60 seconds");
            Assert.Equal(new TimeSpan(0,0,0,60), time);

            time = TimeSpanHelper.Parse("60 second");
            Assert.Equal(new TimeSpan(0,0,0,60), time);

            time = TimeSpanHelper.Parse("1 hour");
            Assert.Equal(new TimeSpan(0,1,0,0), time);

            time = TimeSpanHelper.Parse("2.minutes");
            Assert.Equal(new TimeSpan(0,0,2,0), time);

            time = TimeSpanHelper.Parse("2");
            Assert.Equal(new TimeSpan(0,0,0,2), time);

            Assert.Throws<FormatException>(() => {
                TimeSpanHelper.Parse("60.secondz");
            });

        }
    }
}
