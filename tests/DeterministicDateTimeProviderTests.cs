using switcher;
using Xunit;
using System;

namespace tests
{
    public class DeterministicDateTimeProviderTests
    {
          [Fact]
        public void SwitchOn_IsOnTrue()
        {
            //arrange
            var dateTimeProvider = new DeterministicDateTimeProvider();
            var dateTime = new DateTime(2000,1,1, 12,12,12);
            dateTimeProvider.Time = () => {return dateTime;};

            //act
            var output = dateTimeProvider.UtcNow();

            //assert
            Assert.Equal(dateTime, output);
        }
    }
}
