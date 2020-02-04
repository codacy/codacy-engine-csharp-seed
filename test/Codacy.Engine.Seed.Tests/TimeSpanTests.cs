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
            TimeSpan time = TimeSpanHelper.Parse("60");
            Assert.Equal(new TimeSpan(0,0,0,60), time);

            Assert.Throws<FormatException>(() => {
                TimeSpanHelper.Parse("bla bla");
            });
        }
    }
}
