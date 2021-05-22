using switcher;
using Xunit;
using System;
using Moq;
using Microsoft.Extensions.Logging.Abstractions;

namespace tests
{
    public class MyLightWiringFactoryTests
    {
        [Fact]
        public void TestCreate()
        {
            //arrange
            var light = new Mock<MyLight>(new NullLogger<MyLight>());
            var options = new Mock<SwitcherProviderOptions>();
            var switcher = new Mock<Switcher>(new NullLogger<Switcher>(), options.Object);
            var dateTime = new Mock<IDateTimeProvider>();
            var timer = new Mock<TimedSwitcherProvider>(dateTime.Object);
            var timerWiring = new Mock<MyTimerLightWiring>(light.Object, switcher.Object, timer.Object);

            var serviceProvider = new Moq.Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(MyTimerLightWiring)))
                .Returns(timerWiring.Object);
            serviceProvider
                .Setup(x => x.GetService(typeof(MyLight)))
                .Returns(light.Object);
            serviceProvider
                .Setup(x => x.GetService(typeof(Switcher)))
                .Returns(switcher.Object);
            serviceProvider
                .Setup(x => x.GetService(typeof(IDateTimeProvider)))
                .Returns(dateTime.Object);                
            serviceProvider
                .Setup(x => x.GetService(typeof(TimedSwitcherProvider)))
                .Returns(timer.Object);  


            var factory = new MyLightWiringFactory(serviceProvider.Object);


            //act<
            var actual = factory.Create<MyTimerLightWiring>();

            var isIt = actual as MyTimerLightWiring;
            //assert
            Assert.IsType<MyTimerLightWiring>(isIt);
        }
    }
}
