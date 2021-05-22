using switcher;
using Xunit;
using System;
using System.Linq;

namespace tests
{
    public class TimedSwitcherProviderTests
    {
        [Fact]
        public void SwitchAddOnTime_OnTimeAdded()
        {
            //Arrange
            var provider = new DeterministicDateTimeProvider();
            provider.Time = () => new DateTime(2000, 1, 1, 1, 0, 0);
            var timer = new TimedSwitcherProvider(provider);
            var range = new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1));

            //Act
            timer.AddOnTime(range);

            //Assert
            var actual = timer.OnTimes.First();
            var expected = range;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SwitchRemoveOnTime_OnTimeRemoved()
        {
            //Arrange
            var provider = new DeterministicDateTimeProvider();
            provider.Time = () => new DateTime(2000, 1, 1, 1, 0, 0);
            var timer = new TimedSwitcherProvider(provider);
            var range = new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1));
            timer.AddOnTime(range);

            //Act
            timer.RemoveOnTime(range);

            //Assert
            var actual = timer.OnTimes.Count();
            var expected = 0;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SwitchRemoveOnTimeWithRemoveDifferentInstantationToAdd_OnTimeRemoved()
        {
            //Arrange
            var provider = new DeterministicDateTimeProvider();
            provider.Time = () => new DateTime(2000, 1, 1, 1, 0, 0);
            var timer = new TimedSwitcherProvider(provider);
            var range1 = new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1));
            var range2 = new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1));
            timer.AddOnTime(range1);

            //Act
            timer.RemoveOnTime(range2);

            //Assert
            var actual = timer.OnTimes.Count();
            var expected = 0;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SwitchOff_TurnedOff()
        {
            var provider = new DeterministicDateTimeProvider();
            provider.Time = () => new DateTime(2000, 1, 1, 1, 0, 0);
            var timer = new TimedSwitcherProvider(provider);
            timer.AddOnTime(new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 1)));
            var actual = timer.ShouldBeOn();
            var expected = false;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SwitchOn_TurnedOn()
        {
            var provider = new DeterministicDateTimeProvider();
            provider.Time = () => new DateTime(2000, 1, 1, 1, 0, 0);
            var timer = new TimedSwitcherProvider(provider);
            timer.AddOnTime(new TimeSpanRange(new TimeSpan(0, 0, 0), new TimeSpan(3, 0, 0)));
            var actual = timer.ShouldBeOn();
            var expected = true;
            Assert.Equal(expected, actual);
        }
    }
}
