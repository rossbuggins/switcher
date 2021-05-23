using System;
using System.Collections.Generic;

namespace switcher
{
    public class MultiSwitch : IWiring
    {
        Switcher _switcher;
         public Switcher Switcher => _switcher;
        public MultiSwitch(Switcher switcher)
        {
          //  throw new NotImplementedException("WIP. Class not finished yet.");
            _switcher = switcher;
        }
        public List<MyLight> Lights = new List<MyLight>();
        
        

        public void Enable()
        {
            _switcher.SwitchingProvider.SwitchOnProvider = SwitchOn;
            _switcher.SwitchingProvider.SwitchOffProvider = SwitchOff;
        }

        

        private void SwitchOn()
        {
            foreach(var light in Lights)
            {
                light.On();
            }
        }

        private void SwitchOff()
        {
            foreach(var light in Lights)
            {
                light.Off();
            }
        }
    }

}
