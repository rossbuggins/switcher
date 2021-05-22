using switcher;
using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
namespace tests
{

    public class MyLightTests
    {
        [Fact]
        public void SwitchOn_IsOnTrue()
        {
            //arrange
            var loggger = new NullLogger<MyLight>();
            var x = new MyLight(loggger);

            //act
            x.On();

            //assert
            Assert.True(x.IsOn);
        }

        [Fact]
        public void SwitchOff_IsOffTrue()
        {
            //arrange
            var loggger = new NullLogger<MyLight>();
            var x = new MyLight(loggger);

            //act
            x.Off();

            //assert
            Assert.False(x.IsOn);
        }

        [Fact]
        public void SwitchOffAfterOn_IsOffTrue()
        {
            //arrange
            var loggger = new NullLogger<MyLight>();
            var x = new MyLight(loggger);
            x.On();
            //act
            x.Off();

            //assert
            Assert.False(x.IsOn);
        }
    }
}
