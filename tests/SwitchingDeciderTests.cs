using System;
using Xunit;
using switcher;

namespace tests
{
    public class SwitchingDeciderTests
    {
        [Fact]
        public void Switch_SwitchOn_OnTriggeredFires()
        {
            bool onTriggered = false;
            //arrange
            Func<bool> decider = () => { return true; };
            Action onOn = () => { onTriggered = true; };
            Action onOff = () => { };
            //act
            SwitchingDecider.Switch(decider, onOn, onOff);

            //assert
            Assert.True(onTriggered);
        }

        [Fact]
        public void Switch_SwitchOn_OffTriggeredDoesNotFireFires()
        {
            bool offTriggered = false;
            //arrange
            Func<bool> decider = () => { return true; };
            Action onOn = () => { };
            Action onOff = () => { offTriggered = true; };
            //act
            SwitchingDecider.Switch(decider, onOn, onOff);

            //assert
            Assert.False(offTriggered);
        }

        [Fact]
        public void Switch_SwitchOff_OffTriggeredFires()
        {
            bool offTriggered = false;
            //arrange
            Func<bool> decider = () => { return false; };
            Action onOn = () => { };
            Action onOff = () => { offTriggered = true; };
            //act
            SwitchingDecider.Switch(decider, onOn, onOff);

            //assert
            Assert.True(offTriggered);
        }

        [Fact]
        public void Switch_SwitchOff_OnriggeredNotFires()
        {
            bool onTriggered = false;
            //arrange
            Func<bool> decider = () => { return false; };
            Action onOn = () => { onTriggered = true; };
            Action onOff = () => { };
            //act
            SwitchingDecider.Switch(decider, onOn, onOff);

            //assert
            Assert.False(onTriggered);
        }
    }
}
