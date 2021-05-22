using System;


namespace switcher
{

    public class MyLightWiring
    {
        MyLight _light;
        Switcher _switcher;

        TimedSwitcherProvider _timerSwitch;

        public Switcher Switcher => _switcher;
        public MyLightWiring(
            MyLight light, 
            Switcher switcher, 
            TimedSwitcherProvider timerSwitch)
        {
            _light = light;
            _switcher = switcher;
            _timerSwitch = timerSwitch;
        }

        public void Enable()
        {
            _switcher.SwitchingProvider.SwitchOnProvider = _light.On;
            _switcher.SwitchingProvider.SwitchOffProvider = _light.Off;
            _switcher.SwitchingProvider.ShouldBeOnProvider = _timerSwitch.ShouldBeOn;
           
        }
    }

}
