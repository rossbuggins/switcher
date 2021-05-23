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
            : this (DefaultShouldBeOnProvider, DefaultSwitchOnProvider, DefaultSwitchOffProvider)
        {

        }

        public SwitcherProviderOptions(Func< bool> shouldBeOnProvider, Action switchOnProvider, Action switchOffProvider)
        {
            ShouldBeOnProvider = shouldBeOnProvider;
            SwitchOnProvider = switchOnProvider;
            SwitchOffProvider = switchOffProvider;

        }
    }
}
