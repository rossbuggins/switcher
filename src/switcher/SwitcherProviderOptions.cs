using System;

namespace switcher
{
    public class SwitcherProviderOptions
    {
        public static Func< bool> DefaultShouldBeOnProvider =>()=>{return false;};
        public static Action DefaultSwitchOnProvider =>()=>{};
        public static Action DefaultSwitchOffProvider =>()=>{};
        public Func< bool> ShouldBeOnProvider {get;set;}
        public Action SwitchOnProvider {get;set;}
        public Action SwitchOffProvider {get;set;}

        public SwitcherProviderOptions()
        {
            SwitchOnProvider = DefaultSwitchOnProvider;
            SwitchOffProvider = DefaultSwitchOffProvider;
            ShouldBeOnProvider = DefaultShouldBeOnProvider;
        }
    }
}
