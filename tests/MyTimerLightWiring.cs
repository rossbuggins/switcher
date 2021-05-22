using switcher;
using Xunit;
using System;
using Microsoft.Extensions.Logging.Abstractions;

namespace tests
{
    public class MyTimerLightWiringTests
    {
        [Fact]
        public void WiringEnable_OnProviderAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act
            x.Enable();

            //assert
            Action expected = light.Object.On;
            Action actual = x.Switcher.SwitchingProvider.SwitchOnProvider;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WiringEnable_OffProviderAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act
            x.Enable();

            //assert
            Action expected = light.Object.Off;
            Action actual = x.Switcher.SwitchingProvider.SwitchOffProvider;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WiringEnable_SwitchingProviderAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act
            x.Enable();

            //assert
            Func<bool> expected = timed.Object.ShouldBeOn;
            Func<bool> actual = x.Switcher.SwitchingProvider.ShouldBeOnProvider;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Wiring_OnProviderNotAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act


            //assert
            Action expected = light.Object.On;
            Action actual = x.Switcher.SwitchingProvider.SwitchOnProvider;
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Wiring_OffProviderNotAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act

            //assert
            Action expected = light.Object.Off;
            Action actual = x.Switcher.SwitchingProvider.SwitchOffProvider;
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Wiring_SwitchingProviderNotAssigned()
        {
            //arrange
            var light = new Moq.Mock<MyLight>(new NullLogger<MyLight>());
            var switchOptions = new SwitcherProviderOptions();
            var switcher = new Switcher(new NullLogger<Switcher>(), switchOptions);
            var dateTime = new Moq.Mock<IDateTimeProvider>();
            var timed = new Moq.Mock<TimedSwitcherProvider>(dateTime.Object);
            var x = new MyTimerLightWiring(light.Object, switcher, timed.Object);

            //act

            //assert
            Func<bool> expected = timed.Object.ShouldBeOn;
            Func<bool> actual = x.Switcher.SwitchingProvider.ShouldBeOnProvider;
            Assert.NotEqual(expected, actual);
        }


    }
}
