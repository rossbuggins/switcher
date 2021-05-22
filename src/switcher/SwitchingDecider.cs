using System;

namespace switcher
{
    public class SwitchingDecider
    {
        public static void Switch(Func<bool> shouldBeOnProvider, Action turnOnProvider, Action turnOffProvider)
        {
            if (shouldBeOnProvider())
            {
                turnOnProvider();
            }
            else
            {
                turnOffProvider();
            }
        }
    }
}
